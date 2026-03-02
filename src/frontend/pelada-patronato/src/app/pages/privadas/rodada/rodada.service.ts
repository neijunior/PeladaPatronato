import { inject } from "@angular/core";
import { environment } from "../../../../environments/environment.prod";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Rodada } from "../../../core/models/rodada";

export class RodadaService {
  private http = inject(HttpClient);    
  private baseUrl = `${environment.apiUrl}/rodada`;

  listarRodadas(): Observable<Rodada[]> {
    return this.http.get<Rodada[]>(`${this.baseUrl}`);
  }

  criarRodada(dto: any): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}`, dto);
  }

}