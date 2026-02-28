export interface BaseFiltro {
  pageNumber: number;
  pageSize: number;
  ordenacoes?: Ordenacao[];
}

export interface Ordenacao {
  campo: string;
  direcao: 'asc' | 'desc';
}