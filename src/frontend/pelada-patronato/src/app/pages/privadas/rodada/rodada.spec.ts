import { TestBed } from '@angular/core/testing';

import { Rodada } from './rodada';

describe('Rodada', () => {
  let service: Rodada;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Rodada);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
