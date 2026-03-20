import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RodadaService } from '../../../../core/services/rodada.service';
import { Time } from '../../../../core/models/time';
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

  timesDisponiveis: Time[] = [];

  partidas: { timeA: Time; timeB: Time; ordem: number }[] = [];

  novaPartida: {
    timeA: Time | null;
    timeB: Time | null;
    iniciaCom: 'A' | 'B';
  } = {
      timeA: null,
      timeB: null,
      iniciaCom: 'A'
    };

  constructor(private svcRodada: RodadaService) {
    this.carregarTimes();
  }
  ngOnInit(): void {
    this.carregarPartidas();
  }

  carregarPartidas() {
    this.svcRodada.listarPartidas(this.rodadaId)
      .subscribe(partidas => {
        this.partidas = partidas.map(p => ({
          timeA: this.timesDisponiveis.find(t => t.id === p.rodadaTimeAId)!,
          timeB: this.timesDisponiveis.find(t => t.id === p.rodadaTimeBId)!,
          ordem: p.ordem
        }));
      });
  }

  carregarTimes() {
    this.svcRodada.listarTimes().subscribe({
      next: (times) => {
        this.timesDisponiveis = times;
      },
      error: (err) => {
        console.error('Erro ao carregar times', err);
      }
    });
  }

  adicionarPartida() {

    if (!this.novaPartida.timeA || !this.novaPartida.timeB) return;

    const payload: CriarPartidaRequest = {
      rodadaTimeAId: this.novaPartida.timeA.id,
      rodadaTimeBId: this.novaPartida.timeB.id,
      ordem: this.proximaOrdem,
      timeComPosseInicialId:
        this.novaPartida.iniciaCom === 'A'
          ? this.novaPartida.timeA.id
          : this.novaPartida.timeB.id
    };

    this.svcRodada.criarPartida(this.rodadaId, payload)
      .subscribe({
        next: () => {
          // apenas visual
          this.partidas.push({
            timeA: this.novaPartida.timeA!,
            timeB: this.novaPartida.timeB!,
            ordem: this.proximaOrdem
          });

          this.novaPartida = {
            timeA: null,
            timeB: null,
            iniciaCom: 'A'
          };
        },
        error: (err) => {
          console.error('Erro ao criar partida', err);
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
}