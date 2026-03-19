import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AdicionarParticipante } from '../../components/adicionar-participante/adicionar-participante';
import { Rodada } from '../../../../core/models/rodada';
import { Participante } from '../../../../core/models/participante';
import { ParticipanteService } from '../../../../pages/privadas/participantes/participante.service';
import { ParticipanteFiltro } from '../../../../core/models/filtros/participante-filtro';
import { RodadaService } from '../../../../core/services/rodada.service';

@Component({
  selector: 'app-participantes',
  imports: [CommonModule, AdicionarParticipante],
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
    private participanteService: ParticipanteService
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

    this.participanteService.listar(filtro)
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

    if (!p.diarista) {
      return '#1f2937';
    }

    // 🎯 Se for diarista → divide tipo + pagamento

    const corTipo = '#78350f'; // amarelo/marrom (diarista)

    const corPagamento = p.pago
      ? '#064e3b'   // verde (pago)
      : '#7f1d1d';  // vermelho (pendente)

    return `linear-gradient(to right, 
          ${corTipo} 0%, 
          ${corTipo} 50%, 
          ${corPagamento} 50%, 
          ${corPagamento} 100%)`;
  }

  isRodadaCriada(): boolean {
    return this.rodada?.descricaoStatus?.toLowerCase() === 'criada';
  }

}
