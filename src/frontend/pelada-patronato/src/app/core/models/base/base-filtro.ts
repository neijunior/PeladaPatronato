export interface BaseFiltro {
  pageNumber: number;
  pageSize: number;
  orderBy?: string;
  direction?: 'asc' | 'desc';
}