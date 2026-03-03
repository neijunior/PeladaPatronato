import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RodadaService } from '../rodada.service';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { CommonModule } from '@angular/common';
import { Rodada } from '../../../../core/models/rodada';
import { FormsModule } from '@angular/forms';
import { MontarTimes } from '../components/montar-times/montar-times';
import { AdicionarParticipante } from '../components/adicionar-participante/adicionar-participante';
import { ParticipanteService } from '../../participantes/participante.service';
import { Participante } from '../../../../core/models/participante';
import { ParticipanteFiltro } from '../../../../core/models/filtros/participante-filtro';


@Component({
  selector: 'app-rodada-detalhe',
  imports: [CommonModule, FormsModule, MatDatepickerModule, MatInputModule, MatNativeDateModule, MontarTimes, AdicionarParticipante],
  templateUrl: './rodada-detalhe.html',
  styleUrl: './rodada-detalhe.css',
})
export class RodadaDetalhe implements OnInit {
  todosParticipantes: Participante[] = []
  mostrarPainelTimes = false;

  rodada: Rodada | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private rodadaService: RodadaService,
    private participanteService: ParticipanteService
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.carregarRodada(id);
        this.carregarParticipantes();
      }
    });
  }

  carregarParticipantes() {

    const filtro: ParticipanteFiltro = {
      nome: '',
      pageNumber: 1,
      pageSize: 9999      
    }

    this.participanteService.listar(filtro)
      .subscribe(res => {
        console.log(res);
        this.todosParticipantes = res.items
      })
  }
  carregarRodada(id: string) {
    this.rodadaService.consultar(id)
      .subscribe(res => {
        this.rodada = res;
      });
  }

  voltar() {
    const pagina = this.route.snapshot.queryParamMap.get('pagina');
    const status = this.route.snapshot.queryParamMap.get('status');

    this.router.navigate(
      ['/rodadas'],
      {
        queryParams: {
          pagina,
          status
        }
      }
    );
  }

  onTimesCriados() {
    this.carregarRodada(this.rodada!.id);
    this.mostrarPainelTimes = false;
  }
}
