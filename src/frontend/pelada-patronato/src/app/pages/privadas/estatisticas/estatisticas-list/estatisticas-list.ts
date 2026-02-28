import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { PagedResponse } from '../../../../core/models/base/paged-response';
import { PaginationComponent } from '../../../../shared/components/pagination/pagination/pagination';
import { Estatistica } from '../../../../core/models/estatistica';
import { EstatisticaFiltro } from '../../../../core/models/filtros/estatistica-filtro';
import { EstatisticaService } from '../estatisticas.service';

@Component({
  selector: 'app-estatistica-list',
  standalone: true,
  imports: [CommonModule, FormsModule, PaginationComponent
  ],
  templateUrl: './estatisticas-list.html',
  styleUrls: ['./estatisticas-list.css']
})
export class EstatisticasList implements OnInit {

  estatisticas: Estatistica[] = [];
  totalRegistros = 0;

  carregando = false;
  erro: string | null = null;

  filtro: EstatisticaFiltro = {
    pageNumber: 1,
    pageSize: 10,    
    nomeParticipante: '',
    posicao: 0,
    periodo: '',
    dataInicio: new Date(),
    dataFim: new Date()

  };

  constructor(
    private readonly svc: EstatisticaService,
    private readonly router: Router
  ) {
  }

  ngOnInit(): void {
    this.carregar();
  }

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
      next: (response: PagedResponse<Estatistica>) => {
        this.estatisticas = response.items ?? [];
        this.totalRegistros = response.totalCount ?? 0;
        this.carregando = false;
      },
      error: () => {
        this.erro = 'Erro ao carregar';
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
      pageNumber: 1,
      pageSize: 10,      
    };

    this.carregar();
  }

  mudarPagina(page: number): void {
    if (page === this.filtro.pageNumber) return;

    this.filtro.pageNumber = page;
    this.carregar();
  }
}