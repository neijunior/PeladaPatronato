import { Component, effect, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { Participante } from '../../../../core/models/participante';
import { ParticipanteFiltro } from '../../../../core/models/filtros/participante-filtro';
import { PagedResponse } from '../../../../core/models/base/paged-response';
import { PaginationComponent } from '../../../../shared/components/pagination/pagination/pagination';
import { TelefonePipe } from '../../../../pipes/telefone-pipe';
import { ParticipanteService } from '../../../../core/services/participante.service';
import { ParticipanteFiltroComponent } from '../../components/participante-filtro/participante-filtro';

@Component({
  selector: 'app-participante-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    PaginationComponent,
    TelefonePipe,
    ParticipanteFiltroComponent
  ],
  templateUrl: './participante-list.html',
  styleUrls: ['./participante-list.css']
})
export class ParticipanteList implements OnInit {

  posicoes: { id: number; nome: string }[] = [];
  participantes: PagedResponse<Participante> = { items: [], pageNumber: 1, pageSize: 10, totalCount: 0 };
  totalRegistros = 0;

  @ViewChild(ParticipanteFiltroComponent)
  filtroComponent!: ParticipanteFiltroComponent;

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
    effect(() => {
      this.participantes = this.svc.getParticipantes;
    });
    this.loadPosicoes();
  }

  ngOnInit(): void {
    setTimeout(() => this.filtroComponent.filtrar());
  }

  loadPosicoes() {
    this.svc.listarPosicoes().subscribe({
      next: (res) => this.posicoes = res,
      error: (err) => console.error('Erro ao carregar posições', err)
    });
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

  mudarPagina(page: number): void {
    if (page === this.filtro.pageNumber) return;

    this.filtro.pageNumber = page;

    // 👇 chama o filtro (que chama API)
    this.filtroComponent.filtro.pageNumber = page;
    this.filtroComponent.filtrar();
  }

  editar(id: string): void {
    this.router.navigate(['participantes/novo'], {
      queryParams: { id }
    });
  }

  inativar(id: string): void {
    this.svc.delete(id).subscribe({
      next: () => setTimeout(() => this.filtroComponent.filtrar()),
      error: (err) => console.error('Erro ao inativar participante', err)
    });
  }

  atualizarLista(response: PagedResponse<Participante>) {
    this.participantes = response;
    this.totalRegistros = response.totalCount ?? 0;

    // sincroniza paginação com o backend
    this.filtro.pageNumber = response.pageNumber;
    this.filtro.pageSize = response.pageSize;
  }
}