import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html'
})
export class Login {

  nomeUsuario = '';
  senha = '';
  erro: string | null = null;
  carregando = false;

  constructor(private authService: AuthService,
    private router: Router) { }

  login() {

    this.erro = null;
    this.carregando = true;

    this.authService.login(this.nomeUsuario, this.senha)
      .subscribe({
        next: () => {
          this.carregando = false;
          this.router.navigate(['/dashboard']);
        },
        error: () => {
          this.carregando = false;
          this.erro = 'Email ou senha inválidos';
        }
      });
  }
}
