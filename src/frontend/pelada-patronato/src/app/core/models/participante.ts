export interface Participante {
  id?: number;
  nome: string;
  dataNascimento: string;  // ou Date, se preferir
  telefone?: string;
  // outros campos que você quiser...
}
