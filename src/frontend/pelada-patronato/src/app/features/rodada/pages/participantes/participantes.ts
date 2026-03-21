import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AdicionarParticipante } from '../../components/adicionar-participante/adicionar-participante';
import { Rodada } from '../../../../core/models/rodada';
import { Participante } from '../../../../core/models/participante';
import { ParticipanteFiltro } from '../../../../core/models/filtros/participante-filtro';
import { RodadaService } from '../../../../core/services/rodada.service';
import { ParticipanteService } from '../../../../core/services/participante.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-participantes',
  imports: [CommonModule, AdicionarParticipante, FormsModule],
  templateUrl: './participantes.html',
  styleUrl: './participantes.css',
})
export class Participantes implements OnInit {
  participantesParaTimes: Participante[] = [];
  todosParticipantes: Participante[] = [];
  rodada!: Rodada;

  rodadaId!: string;
  constructor(
    private route: ActivatedRoute,
    private svcRodada: RodadaService,
    private svcParticipante: ParticipanteService
  ) { }

  ngOnInit(): void {
    this.rodadaId = this.route.parent?.snapshot.paramMap.get('id')!;
    this.carregarRodada();
  }

  carregarParticipantes() {

    const filtro: ParticipanteFiltro = {
      nome: '',
      pageNumber: 1,
      pageSize: 9999
    }

    this.svcParticipante.listar(filtro)
      .subscribe(res => {
        this.todosParticipantes = res.items
      })
  }

  carregarRodada() {
    this.svcRodada.consultar(this.rodadaId)
      .subscribe((r: Rodada) => {
        this.rodada = r;

        this.participantesParaTimes =
          r.participantes?.map(p => p.participante) ?? [];
      });

    this.carregarParticipantes();
  }

  removerParticipante(participanteId: string) {
    this.svcRodada.removerParticipante(this.rodadaId, participanteId)
      .subscribe(() => this.carregarRodada());
  }

  gerarBackground(p: any): string {
  if (p.diarista) {
    return '#78350f'; // cor única para diarista
  }

  return '#1f2937'; // padrão
}

  isRodadaCriada(): boolean {
    return this.rodada?.descricaoStatus?.toLowerCase() === 'criada';
  }

  togglePagamento(p: any) {
    const novoStatus = !p.pago;

    this.svcRodada
      .registrarPagamento(this.rodadaId, p.participante.id, novoStatus)
      .subscribe(() => {
        this.carregarRodada();
      });
  }

}
