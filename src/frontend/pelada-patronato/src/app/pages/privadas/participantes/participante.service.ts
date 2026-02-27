import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Participante } from '../../../core/models/participante';
import { map, Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Posicao } from '../../../core/models/posicao';
import { ParticipanteFiltro } from '../../../core/models/filtros/participante-filtro';
import { PagedResponse } from '../../../core/models/base/paged-response';

@Injectable({
  providedIn: 'root'
})

export class ParticipanteService {
  private http = inject(HttpClient);
  private baseUrl = `${environment.apiUrl}/participante`;

  listar(filtro: ParticipanteFiltro): Observable<PagedResponse<Participante>> {
    let lista = this.http.post<PagedResponse<Participante>>(`${this.baseUrl}/listar`, filtro);
    debugger;
    return lista;
  }

  listarPosicoes(): Observable<Posicao[]> {
    return this.http.post<Posicao[]>(`${environment.apiUrl}/lookup/posicao`, null);
  }

  get(id: string): Observable<Participante> {
  return this.http.get<Participante>(`${this.baseUrl}/${id}`);
}

  salvar(p: Participante): Observable<Participante> {
    const payload = {
      id: p.id,
      nome: p.nome,
      apelido: p.apelido,
      telefone: p.telefone,
      ativo: p.ativo,
      posicaoPreferida: p.posicaoPreferida ? Number(p.posicaoPreferida) : null
    };

    return this.http.post<Participante>(`${this.baseUrl}/salvar`, payload);
  }

  update(id: number, p: Participante): Observable<Participante> {
    return this.http.put<Participante>(`${this.baseUrl}/${id}`, p);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
