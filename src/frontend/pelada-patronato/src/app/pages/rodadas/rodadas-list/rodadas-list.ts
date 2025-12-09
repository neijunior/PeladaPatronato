import { Component, OnInit } from '@angular/core';
import { ParticipanteService } from '../../participantes/participante.service';
import { Router } from '@angular/router';

interface Rodada {
  data: Date;
  jogos: number;
  presentes: number;
  gols: number;
  assistencias: number;
}

@Component({
  selector: 'app-rodadas-list',
  imports: [],
  templateUrl: './rodadas-list.html',
  styleUrl:
   './rodadas-list.css',
})
export class RodadasList implements OnInit {
  rodadas: Rodada[] = [
    { data: new Date(2025, 11, 1), jogos: 2, presentes: 18, gols: 10, assistencias: 7 },
    { data: new Date(2025, 11, 8), jogos: 3, presentes: 20, gols: 15, assistencias: 10 },
    { data: new Date(2025, 11, 15), jogos: 2, presentes: 16, gols: 8, assistencias: 5 },
  ];

  constructor(
    private svc: ParticipanteService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadAll();
  }

  loadAll(): void {
    this.svc.list().subscribe({
      next: data => {
        this.rodadas = this.rodadas;
      },
      error: err => {
        console.error('Erro ao carregar participantes', err);
      }
    });
  }

  novoParticipante(): void {
    this.router.navigate(['participantes/novo']);
  }

  editar(id: number | undefined): void {
    if (id != null) {
      this.router.navigate(['participantes/novo'], { queryParams: { id } });
      // ou para outra rota de edição, dependendo do seu roteamento
    }
  }

  // remover(id: number | undefined): void {
  //   if (id == null) return;
  //   this.svc.delete(id).subscribe({
  //     next: () => {
  //       this.participantes = this.participantes.filter(p => p.id !== id);
  //     },
  //     error: err => {
  //       console.error('Erro ao excluir participante', err);
  //     }
  //   });
  // }
}
