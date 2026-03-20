import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaPartidas } from '../../components/lista-partidas/lista-partidas';
import { ModalPartida } from '../../components/modal-partida/modal-partida';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-partidas',
  standalone: true,
  imports: [CommonModule, ListaPartidas, ModalPartida],
  templateUrl: './partidas.html',
})
export class Partidas implements OnInit {

  private route = inject(ActivatedRoute);
  rodadaId: string = '1'; // depois você pega da rota

  ngOnInit(): void {
    this.rodadaId = this.route.parent?.snapshot.paramMap.get('id')!;
  }

  partidaSelecionada: any = null;

  abrirPartida(partida: any) {
    this.partidaSelecionada = partida;
  }

  fecharModal() {
    this.partidaSelecionada = null;
  }

}