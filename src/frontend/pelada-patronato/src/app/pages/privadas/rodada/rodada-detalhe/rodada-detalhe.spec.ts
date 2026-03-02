import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RodadaDetalhe } from './rodada-detalhe';

describe('RodadaDetalhe', () => {
  let component: RodadaDetalhe;
  let fixture: ComponentFixture<RodadaDetalhe>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RodadaDetalhe]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RodadaDetalhe);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
