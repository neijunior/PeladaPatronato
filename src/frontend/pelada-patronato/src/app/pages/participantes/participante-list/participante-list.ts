import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Participante } from '../../../core/models/participante';
import { ParticipanteService } from '../participante.service';

@Component({
  selector: 'app-participante-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './participante-list.html',
  styleUrls: ['./participante-list.css']
})
export class ParticipanteList implements OnInit {
  participantes: Participante[] = [];

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
        this.participantes = data;
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

  remover(id: number | undefined): void {
    if (id == null) return;
    this.svc.delete(id).subscribe({
      next: () => {
        this.participantes = this.participantes.filter(p => p.id !== id);
      },
      error: err => {
        console.error('Erro ao excluir participante', err);
      }
    });
  }
}
