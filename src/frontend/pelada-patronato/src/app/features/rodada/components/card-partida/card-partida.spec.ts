import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardPartida } from './card-partida';

describe('CardPartida', () => {
  let component: CardPartida;
  let fixture: ComponentFixture<CardPartida>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardPartida]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardPartida);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
