import { Participante } from "./participante";

export interface RodadaTimeParticipante {
  timeBaseId: string; 
  NomeTime?: string;
  participantes: Participante[];
  
}
