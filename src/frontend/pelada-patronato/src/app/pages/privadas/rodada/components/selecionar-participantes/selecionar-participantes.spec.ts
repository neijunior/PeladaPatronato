import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelecionarParticipantes } from './selecionar-participantes';

describe('SelecionarParticipantes', () => {
  let component: SelecionarParticipantes;
  let fixture: ComponentFixture<SelecionarParticipantes>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SelecionarParticipantes]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelecionarParticipantes);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
