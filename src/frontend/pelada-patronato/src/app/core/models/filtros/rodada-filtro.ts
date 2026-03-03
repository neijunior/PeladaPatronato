import { BaseFiltro } from "../base/base-filtro";

export interface RodadaFiltro extends BaseFiltro  {
  dataInicio: Date;
  dataFim?: Date;
}