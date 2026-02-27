import { HttpClient } from "@angular/common/http";
import { BaseFiltro } from "../models/base/base-filtro";
import { Observable } from "rxjs";
import { PagedResponse } from "../models/base/paged-response";

export abstract class BaseService<T, F extends BaseFiltro> {

  protected constructor(
    protected http: HttpClient,
    protected baseUrl: string
  ) {}

  listar(filtro: F): Observable<PagedResponse<T>> {
    return this.http.post<PagedResponse<T>>(
      `${this.baseUrl}/listar`,
      filtro
    );
  }

  obterPorId(id: string): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${id}`);
  }

  excluir(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}