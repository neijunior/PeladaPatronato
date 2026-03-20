import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";
import { RodadaFiltro } from "../models/filtros/rodada-filtro";
import { Observable } from "rxjs";
import { PagedResponse } from "../models/base/paged-response";
import { Rodada } from "../models/rodada";
import { Time } from "../models/time";
import { RodadaTime } from "../models/rodadaTime";
import { CriarTimesRequest } from "../models/request/criarTimesRequest";
import { CriarPartidaRequest, RodadaPartida } from "../models/rodadaPartida";

@Injectable({
  providedIn: 'root'
})

export class RodadaService {

  private http = inject(HttpClient);
  private baseUrl = `${environment.apiUrl}/rodadas`;

  listar(filtro: RodadaFiltro): Observable<PagedResponse<Rodada>> {
    return this.http.post<PagedResponse<Rodada>>(`${this.baseUrl}/pesquisar`, filtro);
  }

  consultar(id: string): Observable<Rodada> {
    return this.http.get<Rodada>(`${this.baseUrl}/${id}`);
  }

  listarTimes(): Observable<Time[]> {
    return this.http.post<Time[]>(`${environment.apiUrl}/lookup/time`, null);
  }

  criarTimes(rodadaId: string, request: CriarTimesRequest[]) {
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

  registrarPagamento(rodadaId: string, participanteId: string, pago: boolean) {
    return this.http.patch(
      `${this.baseUrl}/${rodadaId}/participantes/${participanteId}/pagamento`,
      pago
    );
  }

  criarPartida(rodadaId: string, partida: CriarPartidaRequest) {
    return this.http.post(
      `${this.baseUrl}/${rodadaId}/partida`,
      partida
    );
  }

  listarPartidas(rodadaId: string) {
    return this.http.get<RodadaPartida[]>(`${this.baseUrl}/${rodadaId}/partidas`);
  }

}