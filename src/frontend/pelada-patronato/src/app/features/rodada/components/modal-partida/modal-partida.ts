import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal-partida',
  imports: [CommonModule],
  templateUrl: './modal-partida.html',
  styleUrl: './modal-partida.css',
})
export class ModalPartida {
  @Input() partida: any;
  @Output() fechar = new EventEmitter<void>();

  adicionarGol(jogador: any, time: 'A' | 'B') {
    jogador.gols = (jogador.gols || 0) + 1;

    if (time === 'A') {
      this.partida.golsA = (this.partida.golsA || 0) + 1;
    } else {
      this.partida.golsB = (this.partida.golsB || 0) + 1;
    }
  }

  adicionarAssistencia(jogador: any) {
    jogador.assistencias = (jogador.assistencias || 0) + 1;
  }

  fecharModal() {
    this.fechar.emit();
  }

  adicionarGolContra(time: 'A' | 'B') {
  // Se é contra o time A → gol para o B
  if (time === 'A') {
    this.partida.golsB = (this.partida.golsB || 0) + 1;
  } else {
    this.partida.golsA = (this.partida.golsA || 0) + 1;
  }
}

removerGolContra(time: 'A' | 'B') {
  if (time === 'A' && this.partida.golsB > 0) {
    this.partida.golsB--;
  }

  if (time === 'B' && this.partida.golsA > 0) {
    this.partida.golsA--;
  }
}

}
