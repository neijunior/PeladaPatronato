import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";
import { RodadaFiltro } from "../models/filtros/rodada-filtro";
import { Observable } from "rxjs";
import { PagedResponse } from "../models/base/paged-response";
import { Rodada } from "../models/rodada";
import { Time } from "../models/time";

@Injectable({
  providedIn: 'root'
})

export class RodadaService {
  private http = inject(HttpClient);
  private baseUrl = `${environment.apiUrl}/rodadas`;

  listar(filtro: RodadaFiltro): Observable<PagedResponse<Rodada>> {
    let lista = this.http.post<PagedResponse<Rodada>>(`${this.baseUrl}/pesquisar`, filtro);

    return lista;
  }

  consultar(id: string): Observable<Rodada> {
    let rodada = this.http.get<Rodada>(`${this.baseUrl}/${id}`);
    return rodada;
  }

  listarTimes(): Observable<Time[]> {   
    return this.http.post<Time[]>(`${environment.apiUrl}/lookup/time`, null);
  }

  criarTimes(rodadaId: string, request: any) {
    return this.http.post(
      `${this.baseUrl}/${rodadaId}/times`,
      request
    );
  }

  adicionarParticipante(rodadaId: string, request: any) {
    return this.http.post(
      `${this.baseUrl}/rodadas/${rodadaId}/participantes`,
      request
    )
  }

  removerParticipante(rodadaId: string, participanteId: string) {
    return this.http.delete(
      `${this.baseUrl}/rodadas/${rodadaId}/participantes/${participanteId}`
    );
  }

}