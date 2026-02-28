import { Component, OnInit } from '@angular/core';
import { Estatistica } from '../../../../core/models/estatistica';
import { EstatisticaFiltro } from '../../../../core/models/filtros/estatistica-filtro';
import { EstatisticaService } from '../estatisticas.service';
import { Router } from '@angular/router';
import { PagedResponse } from '../../../../core/models/base/paged-response';
import { PaginationComponent } from '../../../../shared/components/pagination/pagination/pagination';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ranking-semestral',
  imports: [CommonModule, FormsModule, PaginationComponent],
  templateUrl: './ranking-semestral.html',
  styleUrl: './ranking-semestral.css',
})
export class RankingSemestral implements OnInit {


  estatisticas: Estatistica[] = [];
  totalRegistros = 0;

  carregando = false;
  erro: string | null = null;

  filtro: EstatisticaFiltro = {
    pageNumber: 1,
    pageSize: 10,
    nomeParticipante: '',    
    periodo: '',
    dataInicio: new Date(),
    dataFim: new Date(),
    ordenacoes: [{ campo: 'TotalGols', direcao: 'desc' }]
  };

  constructor(
    private readonly svc: EstatisticaService,
    private readonly router: Router
  ) {
  }

  ngOnInit(): void {
    const anoAtual = new Date().getFullYear();
    this.gerarSemestres(anoAtual - 1, anoAtual);
    this.limparFiltro();    
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

  get startIndex(): number {
    return (this.filtro.pageNumber - 1) * this.filtro.pageSize;
  }

  limparFiltro(): void {
    this.filtro = {
      ordenacoes: [{ campo: 'TotalGols', direcao: 'desc' }],
      pageNumber: 1,
      pageSize: 10,
      periodo: this.getSemestreAtual()
    };

    this.carregar();
  }

  mudarPagina(page: number): void {
    if (page === this.filtro.pageNumber) return;

    this.filtro.pageNumber = page;
    this.carregar();
  }

  alterarOrdenacao(campo: string) {
    this.filtro.ordenacoes = [
      {
        campo: campo,
        direcao: 'desc' // pode mudar depois se quiser botão asc/desc
      }
    ];
  }

  semestres: string[] = [];
  gerarSemestres(anoInicio: number, anoFim: number) {
    for (let ano = anoInicio; ano <= anoFim; ano++) {
      this.semestres.push(`${ano}.1`);
      if (ano < new Date().getFullYear())
        this.semestres.push(`${ano}.2`);
    }
  }

  getSemestreAtual(): string {
    const hoje = new Date();
    const ano = hoje.getFullYear();
    const mes = hoje.getMonth() + 1; // 1-12
    const semestre = mes <= 6 ? 1 : 2;
    return `${ano}.${semestre}`;
  }
}
