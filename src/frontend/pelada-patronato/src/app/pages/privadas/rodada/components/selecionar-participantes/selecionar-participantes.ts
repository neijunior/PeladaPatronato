import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-selecionar-participantes',
  imports: [],
  templateUrl: './selecionar-participantes.html',
  styleUrl: './selecionar-participantes.css',
})
export class SelecionarParticipantes {
  @Output() participantesSelecionados = new EventEmitter<string[]>();

  selecionar(ids: string[]) {
    this.participantesSelecionados.emit(ids);
  }
}
