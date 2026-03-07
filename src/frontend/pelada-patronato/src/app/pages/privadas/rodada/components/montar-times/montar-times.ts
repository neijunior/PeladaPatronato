import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Participante } from '../../../../../core/models/participante';
import { RodadaService } from '../../rodada.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Time } from '../../../../../core/models/time';

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

  timesTemp: any[] = [];

  timesDisponiveis: Time[] = [];

  constructor(private rodadaService: RodadaService) { }

  ngOnInit(): void {
    this.carregarTimes();
  }

  // 🔹 Buscar lista de times disponíveis
  carregarTimes() {
    this.rodadaService.listarTimes()
      .subscribe(times => {
        console.log('Times disponíveis:', times);
        this.timesDisponiveis = times;
      });

    console.log(this.timesDisponiveis);
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
      times: this.timesTemp
    };

    this.rodadaService
      .criarTimes(this.rodadaId, request)
      .subscribe({
        next: () => {
          this.timesTemp = [];
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
    return this.participantes.find(p => p.id === participanteId)?.nome;
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
}
