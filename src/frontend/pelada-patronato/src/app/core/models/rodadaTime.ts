import { RodadaTimeParticipante } from "./rodadaTimeParticipante";
import { Time } from "./time";

export interface RodadaTime {
  timeBaseId: string;  
  participantes: RodadaTimeParticipante[];
}
