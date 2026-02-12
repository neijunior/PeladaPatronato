import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { tap } from "rxjs";
import { environment } from "../../environments/environment";

@Injectable({ providedIn: 'root' })
export class AuthService {

  //private api = 'https://localhost:7164/auth/login';
  private baseUrl = `${environment.apiUrl}/auth/login`;

  constructor(private http: HttpClient) {}

  login(email: string, senha: string) {
    return this.http.post<any>(this.baseUrl, { email, senha })
      .pipe(tap(response => {
        localStorage.setItem('token', response.token);
      }));
  }

  logout() {
    localStorage.removeItem('token');
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }

  getRole(): string | null {
    const token = localStorage.getItem('token');
    if (!token) return null;

    const payload = JSON.parse(atob(token.split('.')[1]));
    return payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  }
}