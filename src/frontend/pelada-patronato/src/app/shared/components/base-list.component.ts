import { Directive, OnInit } from '@angular/core';
import { BaseFiltro } from '../../core/models/base/base-filtro';
import { BaseService } from '../../core/services/base.service';

@Directive()
// 👆 decorator obrigatório
export abstract class BaseListComponent<T, F extends BaseFiltro> implements OnInit {

  items: T[] = [];
  totalRegistros = 0;
  carregando = false;
  erro: string | null = null;

  filtro!: F;

  protected constructor(
    protected service: BaseService<T, F>
  ) {}

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.carregando = true;

    this.service.listar(this.filtro).subscribe({
      next: response => {
        this.items = response.items;
        this.totalRegistros = response.totalCount;
        this.carregando = false;
      },
      error: err => {
        console.error(err);
        this.erro = 'Erro ao carregar registros.';
        this.carregando = false;
      }
    });
  }

  mudarPagina(page: number): void {
    this.filtro.pageNumber = page;
    this.load();
  }

  excluir(id: string): void {
    this.service.excluir(id).subscribe(() => {
      this.load();
    });
  }
}