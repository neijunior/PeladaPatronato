import { Participante } from "./participante";

export interface Estatistica {
  participanteId: string;
  periodo?: string;
  dataJogo?: Date;
  totalPartidas: number;
  totalGols: number;
  totalAssistencias: number;  
  mediaGols?: number;
  mediaAssistencias?: number;
  participante: Participante
}