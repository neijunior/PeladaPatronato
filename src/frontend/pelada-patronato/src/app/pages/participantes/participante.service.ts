import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Participante } from '../../core/models/participante';
import { map, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Posicao } from '../../core/models/posicao';

@Injectable({
  providedIn: 'root'
})
export class ParticipanteService {
  private http = inject(HttpClient);
  private baseUrl = `${environment.apiUrl}/participante`;

  listar(filtro: { ativo?: boolean; nome?: string; exibePosicao?: boolean }): Observable<Participante[]> {
    return this.http.post<Participante[]>(`${this.baseUrl}/listar`, filtro);
  }

  listarPosicoes(): Observable<Posicao[]> {
    return this.http.post<Posicao[]>(`${environment.apiUrl}/lookup/posicao`, null);
  }

  get(id: string): Observable<Participante> {
    const filtro = {
      id: id
    };
    
    return this.http.post<Participante[]>(`${this.baseUrl}/listar`, filtro).pipe(
      map(res => {
        if (res.length > 0) {
          return res[0]; // pega apenas o primeiro participante
        }
        throw new Error('Participante não encontrado'); // ou retorna null se preferir
      })
    );;
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
