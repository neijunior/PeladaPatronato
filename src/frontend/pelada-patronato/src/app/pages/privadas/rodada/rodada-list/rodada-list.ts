import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RodadaService } from '../rodada.service';
import { Rodada } from '../../../../core/models/rodada';

@Component({
  selector: 'app-rodada-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './rodada-list.html'
})
export class RodadaList implements OnInit {

  rodadas: Rodada[] = [];
  loading = false;
  erroApi = false;

  constructor(private rodadaService: RodadaService) {}

  ngOnInit(): void {
    this.carregarRodadas();
  }

  carregarRodadas(): void {
    this.loading = true;
    this.erroApi = false;

    this.rodadaService.listarRodadas().subscribe({
      next: (res: Rodada[]) => {
        this.rodadas = res;
        this.loading = false;
      },
      error: (err) => {
        console.error('Erro ao carregar rodadas', err);
        this.erroApi = true;
        this.loading = false;
      }
    });
  }

}