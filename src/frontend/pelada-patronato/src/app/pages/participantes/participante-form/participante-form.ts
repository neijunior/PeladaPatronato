import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Participante } from '../../../core/models/participante';
import { ParticipanteService } from '../participante.service';

@Component({
  selector: 'app-participante-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './participante-form.html',
  styleUrls: ['./participante-form.css']
})
export class ParticipanteForm {
  p: Participante = { nome: '', dataNascimento: '', telefone: '' };

  constructor(
    private svc: ParticipanteService,
    private router: Router
  ) {}

  save() {
    this.svc.create(this.p).subscribe({
      next: () => this.router.navigate(['participantes']),
      error: (err) => console.error('Erro ao salvar', err)
    });
  }

  cancel() {
    this.router.navigate(['participantes']);
  }
}
