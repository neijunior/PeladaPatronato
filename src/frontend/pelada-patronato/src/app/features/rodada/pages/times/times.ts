import { Component, OnInit } from '@angular/core';
import { RodadaTime } from '../../../../core/models/rodadaTime';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Rodada } from '../../../../core/models/rodada';
import { MontarTimes } from '../../components/montar-times/montar-times';
import { TimesMontados } from '../../components/times-montados/times-montados';
import { RodadaService } from '../../../../core/services/rodada.service';

@Component({
  selector: 'app-times',
  imports: [CommonModule, MontarTimes, TimesMontados],
  templateUrl: './times.html',
  styleUrl: './times.css',
})
export class Times implements OnInit {

  rodada!: Rodada;
  mostrarPainelTimes = false;
  timesRodada: RodadaTime[] = [];

  constructor(
    private route: ActivatedRoute,
    private svcRodada: RodadaService
  ) { }

  ngOnInit(): void {
    const id = this.route.parent?.snapshot.paramMap.get('id')!;

    this.carregarRodada(id);
  }

  carregarRodada(id: string) {
    this.svcRodada.consultar(id)
      .subscribe(res => {
        this.rodada = res;
        this.timesRodada = res.times || [];
      });
  }

  onTimesCriados() {
    this.carregarRodada(this.rodada.id);
    this.mostrarPainelTimes = false;    
  }

  get participantesParaTimes() {
    return this.rodada?.participantes
      ?.map(rp => rp.participante) || [];
  }

  obterNomeTime = (id: string): string | undefined => {    
    return this.timesRodada.find(t => t.timeBaseId === id)?.nomeTime;
  }

  obterNomeParticipante = (id: string): string | undefined => {
    return this.rodada?.participantes
      ?.find(p => p.participante.id === id)
      ?.participante.nome;
  }

  isRodadaCriada(): boolean {
    return this.rodada?.descricaoStatus?.toLowerCase() === 'criada';
  }
}
