import { CommonModule } from '@angular/common';
import { Component, effect, EventEmitter, Input, Output, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ParticipanteFiltro } from '../../../../core/models/filtros/participante-filtro';
import { ParticipanteService } from '../participante.service';
import { Participante } from '../participante';

@Component({
  selector: 'app-participante-filtro',
  imports: [CommonModule, FormsModule],
  templateUrl: './participante-filtro.html',
  styleUrl: './participante-filtro.css',
})
export class ParticipanteFiltroComponent {
atualizar(arg0: string,$event: any) {
throw new Error('Method not implemented.');
}

  participantes: Participante[] = [];
  
  constructor(
    private readonly svc: ParticipanteService,
  ) {
    effect(() => {
      this.participantes = this.svc.getParticipantes;
    });
  }

  @Input() filtro!:ParticipanteFiltro;
  @Input() posicoes: { id: number; nome: string }[] = [];

  @Output() buscar = new EventEmitter<void>();
  @Output() limpar = new EventEmitter<void>();

  

}
