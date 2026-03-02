import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RodadaPartidas } from './rodada-partidas';

describe('RodadaPartidas', () => {
  let component: RodadaPartidas;
  let fixture: ComponentFixture<RodadaPartidas>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RodadaPartidas]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RodadaPartidas);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
