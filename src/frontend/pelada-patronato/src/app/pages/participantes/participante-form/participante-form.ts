import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
   p: Participante = { id: '00000000-0000-0000-0000-000000000000', nome: '', telefone: '', ativo: true };
   posicaoPreferidaId?: number;
   posicoes: { id: number; nome: string }[] = [];

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

  save() {
  this.svc.salvar(this.p).subscribe({
    next: () => this.router.navigate(['participantes']),
    error: (err) => {
      console.error('Erro ao salvar', err);
      if (err.status === 400) {
        console.error('400 Bad Request: ', err.error);
      } else if (err.status === 500) {
        console.error('Erro do servidor: ', err.error);
      } else {
        console.error('Outro erro: ', err);
      }
    }
  });
}

loadParticipante(id: string) {
    this.svc.get(id).subscribe({
      next: (res) => {
        this.p = res;

      //   if (res.dataCadastro) {
      //   const dt = new Date(res.dataCadastro);
      //   // formata para yyyy-MM-dd
      //   const yyyy = dt.getFullYear();
      //   const mm = String(dt.getMonth() + 1).padStart(2, '0'); // meses começam do 0
      //   const dd = String(dt.getDate()).padStart(2, '0');
      //   this.p.dataCadastro = `${yyyy}-${mm}-${dd}`;
      // }

        if (res.posicaoPreferida) {          
          this.posicaoPreferidaId = res.posicaoPreferida.id;
        }
      },
      error: (err) => console.error('Erro ao carregar participante', err)
    });
  }

  cancel() {
    this.router.navigate(['participantes']);
  }
}
