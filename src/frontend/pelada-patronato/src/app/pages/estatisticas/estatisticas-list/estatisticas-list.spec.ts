import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstatisticasList } from './estatisticas-list';

describe('EstatisticasList', () => {
  let component: EstatisticasList;
  let fixture: ComponentFixture<EstatisticasList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EstatisticasList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EstatisticasList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
