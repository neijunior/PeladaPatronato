import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParticipanteFiltro } from './participante-filtro';

describe('ParticipanteFiltro', () => {
  let component: ParticipanteFiltro;
  let fixture: ComponentFixture<ParticipanteFiltro>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParticipanteFiltro]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParticipanteFiltro);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
