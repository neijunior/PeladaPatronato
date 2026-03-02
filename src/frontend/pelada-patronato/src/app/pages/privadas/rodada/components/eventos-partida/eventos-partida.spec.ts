import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventosPartida } from './eventos-partida';

describe('EventosPartida', () => {
  let component: EventosPartida;
  let fixture: ComponentFixture<EventosPartida>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EventosPartida]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventosPartida);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
