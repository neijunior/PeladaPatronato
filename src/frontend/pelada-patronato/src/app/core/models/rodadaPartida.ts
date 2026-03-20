export interface RodadaPartida {
  id: string;
  rodadaTimeAId: string;
  rodadaTimeBId: string;
  ordem: number;
  timeComPosseInicialId: string; // 'A' ou 'B'
  dataHora?: Date;
  RodadaId: string;
}

export interface CriarPartidaRequest {
  rodadaTimeAId: string;
  rodadaTimeBId: string;
  ordem: number;
  timeComPosseInicialId: string; // 'A' ou 'B'
}