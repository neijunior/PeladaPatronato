import { Participante } from "./participante";

export interface Rodada {
    id: string;
    dataHora: Date;
    valorDiarista: number;
    observacao?: string;
    status?: string;
    tempoPorPartida: number;
    tempoTotal: number;    
    participantes?: Participante[];
    
}