import { Participante } from "../../pages/privadas/participantes/participante";

export interface Rodada {
    id: string;
    dataHora: Date;
    valorDiarista: number;
    observacao?: string;
    status?: number;
    tempoPorPartida: number;
    tempoTotal: number;    
    participantes?: Participante[];
}