import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RodadaService } from '../rodada.service';
import { Rodada } from '../../../../core/models/rodada';
import { RodadaFiltro } from '../../../../core/models/filtros/rodada-filtro';
import { FormsModule } from '@angular/forms';
import { PaginationComponent } from '../../../../shared/components/pagination/pagination/pagination';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { PagedResponse } from '../../../../core/models/base/paged-response';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rodada-list',
  imports: [CommonModule, FormsModule, PaginationComponent, MatDatepickerModule, MatInputModule, MatNativeDateModule],
  templateUrl: './rodada-list.html',
  styleUrl: './rodada-list.css',
})
export class RodadaList implements OnInit {

  rodadas: Rodada[] = [];
  totalRegistros = 0;

  carregando = false;
  erro: string | null = null;

  filtro: RodadaFiltro = {
    pageNumber: 1,
    pageSize: 10,
    dataInicio: new Date(new Date().getFullYear(), 0, 1),
    dataFim: undefined,
    ordenacoes: [{ campo: 'TotalGols', direcao: 'desc' }]
  };

  constructor(
    private readonly svc: RodadaService,
    private readonly router: Router
  ) {
  }

  ngOnInit(): void {
    this.limparFiltro();
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

  aplicarFiltro(): void {
    this.filtro.pageNumber = 1;
    this.carregar();
  }

  limparFiltro() {
    this.filtro = {
      ordenacoes: [{ campo: 'TotalGols', direcao: 'desc' }],
      pageNumber: 1,
      pageSize: 10,
      //dataInicio: new Date(new Date().getFullYear(), new Date().getMonth(), 1)
      dataInicio: new Date(new Date().getFullYear(), 0, 1)
    };

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
      next: (response: PagedResponse<Rodada>) => {
        this.rodadas = response.items ?? [];
        this.totalRegistros = response.totalCount ?? 0;
        this.carregando = false;
      },
      error: () => {
        this.erro = 'Erro ao carregar';
        this.carregando = false;
      }
    });
  }

  fechar(Id: string) {
    throw new Error('Method not implemented.');
  }

  visualizar(id: string) {
    this.router.navigate(
      ['/rodadas', id],
      {
        queryParams: {
          pagina: this.filtro.pageNumber,
        }
      }
    );
  }

}