import { BaseFiltro } from "../base/base-filtro";

export interface ParticipanteFiltro extends BaseFiltro  {
  id?: string;
  idPosicao?: number;
  ativo?: boolean;
  nome?: string; 
  exibePosicao?: boolean
}