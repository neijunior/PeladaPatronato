import { Participante } from "./participante";
import { RodadaTimeParticipante } from "./rodadaTimeParticipante";


export interface RodadaTime {
  timeBaseId: string;  
  nomeTime: string;
  participantes: Participante[];
}
