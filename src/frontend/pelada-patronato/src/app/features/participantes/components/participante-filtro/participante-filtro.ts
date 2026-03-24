import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ParticipanteFiltro } from '../../../../core/models/filtros/participante-filtro';
import { ParticipanteService } from '../../../../core/services/participante.service';
import { Router } from '@angular/router';
import { PagedResponse } from '../../../../core/models/base/paged-response';
import { Participante } from '../../../../core/models/participante';

@Component({
  selector: 'app-participante-filtro',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './participante-filtro.html',
  styleUrl: './participante-filtro.css',
})
export class ParticipanteFiltroComponent implements OnInit {

  @Output() resultadoChange = new EventEmitter<PagedResponse<Participante>>();
  constructor(
    private readonly svc: ParticipanteService,
    private readonly router: Router
  ) {

  }
  ngOnInit(): void {
    this.limparFiltro();
  }

  filtro!: ParticipanteFiltro;
  @Input() posicoes: { id: number; nome: string }[] = [];

  novoParticipante(): void {
    this.router.navigate(['participantes/novo']);
  }

  filtrar() {
    this.svc.listar(this.filtro).subscribe({
      next: (res) => {
        this.svc.setParticipantes = res;
        this.resultadoChange.emit(res);
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
