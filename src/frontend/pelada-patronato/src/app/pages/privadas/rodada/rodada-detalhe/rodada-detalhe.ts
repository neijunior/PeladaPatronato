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
import { TimesMontados } from '../components/times-montados/times-montados';
import { RodadaTime } from '../../../../core/models/rodadaTime';


@Component({
  selector: 'app-rodada-detalhe',
  imports: [CommonModule, FormsModule, MatDatepickerModule, MatInputModule, MatNativeDateModule, MontarTimes, AdicionarParticipante, TimesMontados],
  templateUrl: './rodada-detalhe.html',
  styleUrl: './rodada-detalhe.css',
})
export class RodadaDetalhe implements OnInit {

  todosParticipantes: Participante[] = []
  mostrarPainelTimes = false;

  rodada: Rodada | undefined;
  exibeMontarTimes: Boolean = true;

  timesRodada: RodadaTime[] = [];

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
  removerParticipante(idParticipante: string) {
    if (!idParticipante) return;

    this.rodadaService.removerParticipante(this.rodada!.id, idParticipante).subscribe(() => {
      this.carregarRodada(this.rodada!.id);
    })
  }

  carregarParticipantes() {

    const filtro: ParticipanteFiltro = {
      nome: '',
      pageNumber: 1,
      pageSize: 9999
    }

    this.participanteService.listar(filtro)
      .subscribe(res => {
        this.todosParticipantes = res.items
      })
  }

  carregarRodada(id: string) {
    this.rodadaService.consultar(id)

      .subscribe(res => {
        debugger;
        this.rodada = res;
        this.timesRodada = res.times || [];
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

  onTimesCriados() {
    this.carregarRodada(this.rodada!.id);
    this.mostrarPainelTimes = false;
    this.carregarTimesRodada();
  }

  carregarTimesRodada() {

    // this.rodadaService
    //   .listarTimesRodada(this.rodada!.id)
    //   .subscribe(times => {
    //     this.timesRodada = times;
    //     this.exibeMontarTimes = times.length > 0;
    //   });

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

  gerarBackground(p: any): string {

    if (!p.diarista) {
      return '#1f2937';
    }

    // 🎯 Se for diarista → divide tipo + pagamento

    const corTipo = '#78350f'; // amarelo/marrom (diarista)

    const corPagamento = p.pago
      ? '#064e3b'   // verde (pago)
      : '#7f1d1d';  // vermelho (pendente)

    return `linear-gradient(to right, 
          ${corTipo} 0%, 
          ${corTipo} 50%, 
          ${corPagamento} 50%, 
          ${corPagamento} 100%)`;
  }

  obterNomeTime = (id: string): string | undefined => {    
    const time = this.timesRodada.find(t => t.timeBaseId === id);    
    return time?.nomeTime; // ajuste conforme seu model
  }

  obterNomeParticipante = (id: string): string | undefined => {
    return this.rodada?.participantes
      ?.find(p => p.participante.id === id)
      ?.participante.nome;
  }
}
