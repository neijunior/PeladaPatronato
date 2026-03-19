import { Participante } from "./participante";


export interface RodadaTime {
  timeBaseId: string;  
  nomeTime: string;
  participantes: Participante[];
}
