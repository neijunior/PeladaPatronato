export interface PagedRequest {
  pageNumber?: number;
  pageSize?: number;
  orderBy?: string;
  ascending?: boolean;
}