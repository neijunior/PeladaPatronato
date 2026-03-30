import { RodadaTimeParticipante } from "./rodadaTimeParticipante";

export interface RodadaPartida {
  id: string;
  rodadaTimeAId: string;
  rodadaTimeBId: string;
  ordem: number;
  timeComPosseInicialId: string; // 'A' ou 'B'
  dataHora?: Date;
  RodadaId: string;
  TimeA?: RodadaTimeParticipante;
  TimeB?: RodadaTimeParticipante;
}

export interface CriarPartidaRequest {
  rodadaTimeAId: string;
  rodadaTimeBId: string;
  ordem: number;
  timeComPosseInicialId: string; // 'A' ou 'B'
}