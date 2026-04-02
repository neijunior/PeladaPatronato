import { Component, effect, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AdicionarParticipante } from '../../components/adicionar-participante/adicionar-participante';
import { Rodada } from '../../../../core/models/rodada';
import { Participante } from '../../../../core/models/participante';
import { ParticipanteFiltro } from '../../../../core/models/filtros/participante-filtro';
import { RodadaService } from '../../../../core/services/rodada.service';
import { ParticipanteService } from '../../../../core/services/participante.service';
import { FormsModule } from '@angular/forms';
import { RodadaStateService } from '../../rodadaStateService';

@Component({
  selector: 'app-participantes',
  imports: [CommonModule, AdicionarParticipante, FormsModule],
  templateUrl: './participantes.html',
  styleUrl: './participantes.css',
})
export class Participantes implements OnInit {
  @Output() alterado = new EventEmitter<void>();

  participantesParaTimes: Participante[] = [];
  todosParticipantes: Participante[] = [];
  rodada!: Rodada;
  rodadaId!: string;

  constructor(
    private route: ActivatedRoute,
    private svcRodada: RodadaService,
    private svcParticipante: ParticipanteService,
    private rodadaState: RodadaStateService,
    private router: Router,
  ) {
    // 🔥 effect correto (com proteção de id)
    effect(() => {
      this.rodadaState.atualizado();

      if (this.rodadaId) {
        this.carregarRodada(this.rodadaId);
      }
    });
  }

  ngOnInit(): void {
    this.rodadaId = this.route.parent?.snapshot.paramMap.get('id')!;
    this.carregarRodada(this.rodadaId);
  }

  carregarParticipantes() {
    const filtro: ParticipanteFiltro = {
      nome: '',
      pageNumber: 1,
      pageSize: 9999
    };

    this.svcParticipante.listar(filtro)
      .subscribe(res => {
        this.todosParticipantes = res.items;
      });
  }

  carregarRodada(id: string) {
    this.svcRodada.consultar(id)
      .subscribe((r: Rodada) => {
        this.rodada = r;
        this.participantesParaTimes =
          r.participantes?.map(p => p.participante) ?? [];
      });

    this.carregarParticipantes();
  }

  removerParticipante(participanteId: string) {
    this.svcRodada.removerParticipante(this.rodadaId, participanteId)
      .subscribe(() => {
        this.carregarRodada(this.rodadaId);
        this.rodadaState.notificar(); // 🔥 dispara atualização global
      });
  }

  togglePagamento(p: any) {
    const novoStatus = !p.pago;

    this.svcRodada
      .registrarPagamento(this.rodadaId, p.participante.id, novoStatus)
      .subscribe(() => {
        this.carregarRodada(this.rodadaId);
        this.rodadaState.notificar(); // 🔥 dispara atualização global
      });
  }

  gerarBackground(p: any): string {
    return p.diarista ? '#78350f' : '#1f2937';
  }

  isRodadaCriada(): boolean {
    return this.rodada?.descricaoStatus?.toLowerCase() === 'criada';
  }

  alterarStatusRodada(status: number) {
  this.svcRodada.alterarStatusRodada(this.rodadaId, status)
    .subscribe({
      next: () => {          
        this.router.navigate(['../times'], { relativeTo: this.route });
      },
      error: (err) => {          
        alert('Erro ao fechar rodada. Tente novamente.');
      }
    });
  }
}