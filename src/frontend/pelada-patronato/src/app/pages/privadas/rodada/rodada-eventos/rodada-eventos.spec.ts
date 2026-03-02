import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RodadaEventos } from './rodada-eventos';

describe('RodadaEventos', () => {
  let component: RodadaEventos;
  let fixture: ComponentFixture<RodadaEventos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RodadaEventos]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RodadaEventos);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
