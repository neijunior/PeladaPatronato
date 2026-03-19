import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Participante } from '../models/participante';
import { environment } from '../../../environments/environment';
import { ParticipanteFiltro } from '../models/filtros/participante-filtro';
import { PagedResponse } from '../models/base/paged-response';
import { Posicao } from '../models/posicao';



@Injectable({
  providedIn: 'root'
})

export class ParticipanteService {
  private http = inject(HttpClient);
  private baseUrl = `${environment.apiUrl}/participante`;

  private participantesSignal = signal<Participante[]>([]);

  get getParticipantes() {
    return this.participantesSignal();
  }

  set setParticipantes(value: Participante[]) {
    this.participantesSignal.set(value);
  }

  listar(filtro: ParticipanteFiltro): Observable<PagedResponse<Participante>> {
    return this.http.post<PagedResponse<Participante>>(`${this.baseUrl}/listar`, filtro);    
  }

  listarPosicoes(): Observable<Posicao[]> {
    return this.http.post<Posicao[]>(`${environment.apiUrl}/lookup/posicao`, null);
  }

  get(id: string): Observable<Participante> {
    return this.http.get<Participante>(`${this.baseUrl}/consultar?Id=${id}`);
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
