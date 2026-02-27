import { Participante } from "./participante";

export interface Estatistica {
  participanteId: string;
  periodo?: Date;
  dataJogo?: Date;
  totalPartidas: number;
  totalGols: number;
  totalAssistencias: number;  
  mediaGols?: number;
  mediaAssistencias?: number;
  participante: Participante
}