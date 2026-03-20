import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaPartidas } from './lista-partidas';

describe('ListaPartidas', () => {
  let component: ListaPartidas;
  let fixture: ComponentFixture<ListaPartidas>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListaPartidas]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaPartidas);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
