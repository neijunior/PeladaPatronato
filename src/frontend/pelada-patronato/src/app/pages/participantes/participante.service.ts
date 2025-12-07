import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Participante } from '../../core/models/participante';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ParticipanteService {
  private http = inject(HttpClient);
  private baseUrl = 'https://api.seu-backend.com/participantes';

  list(): Observable<Participante[]> {
    return this.http.get<Participante[]>(this.baseUrl);
  }

  get(id: number): Observable<Participante> {
    return this.http.get<Participante>(`${this.baseUrl}/${id}`);
  }

  create(p: Participante): Observable<Participante> {
    return this.http.post<Participante>(this.baseUrl, p);
  }

  update(id: number, p: Participante): Observable<Participante> {
    return this.http.put<Participante>(`${this.baseUrl}/${id}`, p);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
