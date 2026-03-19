import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { CommonModule } from '@angular/common';
import { Rodada } from '../../../../core/models/rodada';
import { FormsModule } from '@angular/forms';
import { ParticipanteService } from '../../../../pages/privadas/participantes/participante.service';
import { RodadaService } from '../../../../core/services/rodada.service';


@Component({
  selector: 'app-rodada-detalhe',
  imports: [CommonModule, FormsModule, MatDatepickerModule, MatInputModule, MatNativeDateModule, RouterModule],
  templateUrl: './rodada-detalhe.html',
  styleUrl: './rodada-detalhe.css',
})
export class RodadaDetalhe implements OnInit {

  rodada: Rodada | undefined;
  exibeMontarTimes: Boolean = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private svcRodada: RodadaService,
    private participanteService: ParticipanteService
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.carregarRodada(id);
      }
    });
  }
  

  carregarRodada(id: string) {
    this.svcRodada.consultar(id)

      .subscribe(res => {
        this.rodada = res;
        this.exibeMontarTimes = res.descricaoStatus !== 'Criada';
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

  get mensalistas(): number {
    return this.rodada?.participantes?.filter(p => !p.diarista).length || 0;
  }

  get diaristas(): number {
    return this.rodada?.participantes?.filter(p => p.diarista).length || 0;
  }

  get valorPrevisto(): number {
    return this.diaristas * (this.rodada?.valorDiarista || 0);
  }

  get valorPago(): number {
    return this.rodada?.participantes
      ?.filter(p => p.diarista && p.pago)
      .reduce((total, p) => total + (this.rodada?.valorDiarista || 0), 0) || 0;
  }

  get valorPendente(): number {
    return this.valorPrevisto - this.valorPago;
  }

  get participantesParaTimes() {
    return this.rodada?.participantes
      ?.map(rp => rp.participante) || [];
  }
}
