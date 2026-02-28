import { BaseFiltro } from "../base/base-filtro";

export interface EstatisticaFiltro extends BaseFiltro {
  nomeParticipante?: string;
  posicao?: 0;
  periodo?: string;
  dataInicio?: Date;
  dataFim?: Date;
}


