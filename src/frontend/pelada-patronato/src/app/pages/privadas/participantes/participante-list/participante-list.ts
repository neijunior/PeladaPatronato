import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { Participante } from '../../../../core/models/participante';
import { ParticipanteService } from '../participante.service';
import { ParticipanteFiltro } from '../../../../core/models/filtros/participante-filtro';
import { PagedResponse } from '../../../../core/models/base/paged-response';
import { PaginationComponent } from '../../../../shared/components/pagination/pagination/pagination';

@Component({
  selector: 'app-participante-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    PaginationComponent
  ],
  templateUrl: './participante-list.html',
  styleUrls: ['./participante-list.css']
})
export class ParticipanteList implements OnInit {

  posicoes: { id: number; nome: string }[] = [];
  participantes: Participante[] = [];
  totalRegistros = 0;

  carregando = false;
  erro: string | null = null;

  filtro: ParticipanteFiltro = {
    nome: '',
    pageNumber: 1,
    pageSize: 10,
    ativo: true,
    exibePosicao: true    
  };

  constructor(
    private readonly svc: ParticipanteService,
    private readonly router: Router
  ) { 
    this.loadPosicoes();
  }

  ngOnInit(): void {
    this.carregar();
  }

  loadPosicoes() {
    this.svc.listarPosicoes().subscribe({
      next: (res) => this.posicoes = res,
      error: (err) => console.error('Erro ao carregar posições', err)
    });
  }
  // ===============================
  // GETTERS PAGINAÇÃO
  // ===============================

  get registroInicial(): number {
    return this.totalRegistros === 0
      ? 0
      : (this.filtro.pageNumber - 1) * this.filtro.pageSize + 1;
  }

  get registroFinal(): number {
    const fim = this.filtro.pageNumber * this.filtro.pageSize;
    return fim > this.totalRegistros
      ? this.totalRegistros
      : fim;
  }

  private carregar(): void {
    this.carregando = true;
    this.erro = null;

    this.svc.listar(this.filtro).subscribe({
      next: (response: PagedResponse<Participante>) => {
        this.participantes = response.items ?? [];
        this.totalRegistros = response.totalCount ?? 0;
        this.carregando = false;
      },
      error: () => {
        this.erro = 'Erro ao carregar participantes';
        this.carregando = false;
      }
    });
  }

  aplicarFiltro(): void {
    this.filtro.pageNumber = 1;
    this.carregar();
  }

  limparFiltro(): void {
    this.filtro = {
      nome: '',
      pageNumber: 1,
      pageSize: 10,
      ativo: true,
      exibePosicao: true     

    };

    this.carregar();
  }

  mudarPagina(page: number): void {
    if (page === this.filtro.pageNumber) return;

    this.filtro.pageNumber = page;
    this.carregar();
  }

  // ===============================
  // NAVEGAÇÃO
  // ===============================

  novoParticipante(): void {
    this.router.navigate(['participantes/novo']);
  }

  editar(id: string): void {
    this.router.navigate(['participantes/novo'], {
      queryParams: { id }
    });
  }

  inativar(id: string): void {
    this.svc.delete(id).subscribe({
      next: () => this.carregar(),
      error: (err) => console.error('Erro ao inativar participante', err)
    });
  }
}