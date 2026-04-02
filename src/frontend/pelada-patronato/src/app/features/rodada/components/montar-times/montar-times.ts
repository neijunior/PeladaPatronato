import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Participante } from '../../../../core/models/participante';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Time } from '../../../../core/models/time';
import { RodadaService } from '../../../../core/services/rodada.service';
import { CriarTimesRequest } from '../../../../core/models/request/criarTimesRequest';

@Component({
  selector: 'app-montar-times',
  imports: [CommonModule, FormsModule],
  templateUrl: './montar-times.html',
  styleUrl: './montar-times.css',
})
export class MontarTimes implements OnInit {
  @Input() rodadaId!: string;
  @Input() participantes: Participante[] = [];

  @Output() timesCriados = new EventEmitter<void>();

  timeSelecionado: string | null = null;
  participantesSelecionados: string[] = [];
  timesSalvos = false;

  timesTemp: any[] = [];

  timesDisponiveis: Time[] = [];

  constructor(private svcRodada: RodadaService) { }

  ngOnInit(): void {
    this.carregarTimes();
  }

  carregarTimes() {
    this.svcRodada.listarTimes()
      .subscribe(times => {
        this.timesDisponiveis = times;
      });
  }

  // 🔹 Adiciona time na estrutura temporária
  adicionarTimeTemp() {

    if (!this.timeSelecionado || this.participantesSelecionados.length === 0)
      return;

    const participantesJaUsados = this.timesTemp
      .flatMap(t => t.participantesIds);

    const duplicado = this.participantesSelecionados
      .some(p => participantesJaUsados.includes(p));

    if (duplicado) return;

    // evita duplicar o mesmo time
    const jaExiste = this.timesTemp.some(t => t.timeId === this.timeSelecionado);
    if (jaExiste) return;

    this.timesTemp.push({
      timeId: this.timeSelecionado,
      participantesIds: [...this.participantesSelecionados]
    });

    this.timeSelecionado = null;
    this.participantesSelecionados = [];
  }

  // 🔹 Envia para backend
  salvarTimes() {

  if (this.timesTemp.length === 0)
    return;

  const request = {
    times: this.timesTemp.map(t => ({
      timeId: t.timeId,
      participantesIds: t.participantesIds
    }))
  };

  this.svcRodada
    .criarTimes(this.rodadaId, request)
    .subscribe({
      next: () => {
        this.timesTemp = [];
        this.timesSalvos = true;
        this.timesCriados.emit();
      },
      error: err => {
        console.error(err);
      }
    });
}

  // 🔹 Helpers para exibição
  obterNomeTime(timeId: string) {
    return this.timesDisponiveis.find(t => t.id === timeId)?.nome;
  }

  obterNomeParticipante(participanteId: string) {    
    const participante = this.participantes.find(p => p.id === participanteId);
    return participante ? `${participante.nome}${participante.apelido ? ' - ' + participante.apelido : ''}` : '';
  }

  get timesDisponiveisFiltrados(): Time[] {

    const usados = this.timesTemp.map(t => t.timeId);

    return this.timesDisponiveis
      .filter(t => !usados.includes(t.id));
  }

  get participantesDisponiveis(): Participante[] {

    const usados = this.timesTemp
      .flatMap(t => t.participantesIds);

    return this.participantes
      .filter(p => !usados.includes(p.id));
  }

  toggleParticipante(id: string) {
  const index = this.participantesSelecionados.indexOf(id);

  if (index === -1) {
    this.participantesSelecionados.push(id);
  } else {
    this.participantesSelecionados.splice(index, 1);
  }
}
}
