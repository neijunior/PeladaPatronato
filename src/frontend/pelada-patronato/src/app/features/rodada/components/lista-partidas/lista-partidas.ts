import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RodadaService } from '../../../../core/services/rodada.service';
import { CriarPartidaRequest } from '../../../../core/models/rodadaPartida';

@Component({
  selector: 'app-lista-partidas',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './lista-partidas.html',
})
export class ListaPartidas implements OnInit {

  @Input() rodadaId!: string;
  @Output() selecionar = new EventEmitter<any>();

  partidas: any[] = [];
  podeAdicionarPartida = false;

  novaPartida: {
    timeAId: string | null;
    timeBId: string | null;
    iniciaCom: 'A' | 'B';
  } = {
    timeAId: null,
    timeBId: null,
    iniciaCom: 'A'
  };

  constructor(private svcRodada: RodadaService) {}

  ngOnInit(): void {
    this.carregarTudo();
  }

  carregarTudo() {
    this.carregarPartidas();
    this.getPodeAdicionarPartida();
  }

  carregarPartidas() {
    this.svcRodada.listarPartidas(this.rodadaId)
      .subscribe(partidas => {
        this.partidas = partidas;
      });
  }

  getPodeAdicionarPartida(): void {
    this.svcRodada.consultar(this.rodadaId)
      .subscribe(rodada => {
        this.podeAdicionarPartida =
          rodada.descricaoStatus?.toLowerCase() !== 'partidas geradas';
      });
  }

  adicionarPartida() {
    if (!this.novaPartida.timeAId || !this.novaPartida.timeBId) return;

    const payload: CriarPartidaRequest = {
      rodadaTimeAId: this.novaPartida.timeAId,
      rodadaTimeBId: this.novaPartida.timeBId,
      ordem: this.proximaOrdem,
      timeComPosseInicialId:
        this.novaPartida.iniciaCom === 'A'
          ? this.novaPartida.timeAId
          : this.novaPartida.timeBId
    };

    this.svcRodada.criarPartida(this.rodadaId, payload)
      .subscribe({
        next: () => {
          // 🔥 recarrega do backend (fonte da verdade)
          this.carregarPartidas();

          this.novaPartida = {
            timeAId: null,
            timeBId: null,
            iniciaCom: 'A'
          };
        }
      });
  }

  selecionarPartida(partida: any) {
    this.selecionar.emit(partida);
  }

  get proximaOrdem(): number {
    if (this.partidas.length === 0) return 1;
    return Math.max(...this.partidas.map(p => p.ordem)) + 1;
  }
  
  alterarStatusRodada(status: number) {
  this.svcRodada.alterarStatusRodada(this.rodadaId, status)
    .subscribe({
      next: () => {          
        this.podeAdicionarPartida = true;
      },
      error: (err) => {          
        alert('Erro ao fechar rodada. Tente novamente.');
      }
    });
}
}