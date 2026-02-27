import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Participante } from '../../../../core/models/participante';
import { Posicao } from '../../../../core/models/posicao';
import { ParticipanteService } from '../participante.service';

@Component({
  selector: 'app-participante-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './participante-form.html',
  styleUrls: ['./participante-form.css']
})
export class ParticipanteForm {

  p: Participante = {
    id: '00000000-0000-0000-0000-000000000000',
    nome: '',
    telefone: '',
    ativo: true
  };

  posicoes: Posicao[] = [];

  constructor(
    private svc: ParticipanteService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.loadPosicoes();

    const id = this.route.snapshot.queryParamMap.get('id');
    if (id) {
      this.loadParticipante(id);
    }
  }

  loadPosicoes() {
    this.svc.listarPosicoes().subscribe({
      next: (res) => this.posicoes = res,
      error: (err) => console.error('Erro ao carregar posições', err)
    });
  }

  loadParticipante(id: string) {
    this.svc.get(id).subscribe({
      next: (res) => {
        this.p = res;
      },
      error: (err) => console.error('Erro ao carregar participante', err)
    });
  }

  save() {
    this.svc.salvar(this.p).subscribe({
      next: () => this.router.navigate(['participantes']),
      error: (err) => {
        console.error('Erro ao salvar', err);
      }
    });
  }

  cancel() {
    this.router.navigate(['participantes']);
  }
}