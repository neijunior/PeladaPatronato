import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { RodadaService } from '../../rodada.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Participante } from '../../../../../core/models/participante';

@Component({
  standalone: true,
  selector: 'app-adicionar-participante',
  imports: [CommonModule, FormsModule],
  templateUrl: './adicionar-participante.html',
  styleUrl: './adicionar-participante.css',
})
export class AdicionarParticipante implements OnChanges{
  @Input() rodadaId!: string
  
  @Input() participantes: Participante[] = []
  @Input() participantesRodada: Participante[] = []

  @Output() participanteAdicionado = new EventEmitter<void>()

  participantesDisponiveis: Participante[] = []
  participanteSelecionadoId!: string
  diarista: boolean = false

  constructor(private rodadaService: RodadaService) { }
  
  ngOnChanges(changes: SimpleChanges): void {
    this.atualizarDisponiveis();
  }

  atualizarDisponiveis() {
    const idsRodada = this.participantesRodada.map(p => p.id);

    this.participantesDisponiveis = this.participantes
      .filter(p => !idsRodada.includes(p.id));
  }

  adicionar() {
    if (!this.participanteSelecionadoId) return;

    this.rodadaService.adicionarParticipante(
      this.rodadaId,
      {
        participanteId: this.participanteSelecionadoId,
        diarista: this.diarista
      }
    ).subscribe(() => {
      this.participanteAdicionado.emit()
      this.participanteSelecionadoId = ''
      this.diarista = false
    })
  }


}