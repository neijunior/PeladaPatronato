import { Participante } from "./participante";
import { RodadaParticipante } from "./rodadaParticipante";

export interface Rodada {
    id: string;
    dataHora: Date;
    valorDiarista: number;
    observacao?: string;
    descricaoStatus?: string;
    tempoPorPartida: number;
    tempoTotal: number;    
    participantes?: RodadaParticipante[];
    
}