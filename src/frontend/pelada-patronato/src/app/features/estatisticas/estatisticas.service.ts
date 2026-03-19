import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { PagedResponse } from '../../core/models/base/paged-response';
import { EstatisticaFiltro } from '../../core/models/filtros/estatistica-filtro';
import { Estatistica } from '../../core/models/estatistica';

@Injectable({
    providedIn: 'root'
})

export class EstatisticaService {
    private http = inject(HttpClient);
    private baseUrl = `${environment.apiUrl}/estatistica`;

    listar(filtro: EstatisticaFiltro): Observable<PagedResponse<Estatistica>> {        
        return this.http.post<PagedResponse<Estatistica>>(`${this.baseUrl}/listar`, filtro);        
    }
}
