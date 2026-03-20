import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalPartida } from './modal-partida';

describe('ModalPartida', () => {
  let component: ModalPartida;
  let fixture: ComponentFixture<ModalPartida>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalPartida]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalPartida);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
