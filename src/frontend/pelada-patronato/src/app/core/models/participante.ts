import { Posicao } from "./posicao";

export interface Participante {
  id: string;
  nome: string;
  apelido?: string;
  telefone?: string;  
  posicaoPreferida?:Posicao;
  ativo: boolean;
  dataCadastro?: Date;
  email?: string
  // outros campos que você quiser...
}
