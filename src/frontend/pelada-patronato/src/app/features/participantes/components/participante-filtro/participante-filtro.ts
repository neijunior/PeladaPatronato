import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ParticipanteFiltro } from '../../../../core/models/filtros/participante-filtro';
import { ParticipanteService } from '../../../../core/services/participante.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-participante-filtro',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './participante-filtro.html',
  styleUrl: './participante-filtro.css',
})
export class ParticipanteFiltroComponent {

  constructor(
    private readonly svc: ParticipanteService,
    private readonly router: Router
  ) {

  }

  filtro!: ParticipanteFiltro;
  @Input() posicoes: { id: number; nome: string }[] = [];

  novoParticipante(): void {
    this.router.navigate(['participantes/novo']);
  }

  filtrar() {    
    this.svc.listar(this.filtro).subscribe({
      next: (res) => {
        this.svc.setParticipantes = res.items;
      },
      error: (err) => {
        console.error('Erro ao buscar participantes:', err);
      }
    });
  }

  limparFiltro(): void {
    this.filtro = {
      nome: '',
      pageNumber: 1,
      pageSize: 10,
      ativo: true,
      exibePosicao: true     

    };

    //this.carregar();
  }

}
