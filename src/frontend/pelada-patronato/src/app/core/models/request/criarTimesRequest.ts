export interface CriarTimesRequest {
  times: CriarTimeItemRequest[];
}

export interface CriarTimeItemRequest {
  timeId: string;      
  participantesIds: string[];
}