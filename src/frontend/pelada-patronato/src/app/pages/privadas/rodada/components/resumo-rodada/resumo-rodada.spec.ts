import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResumoRodada } from './resumo-rodada';

describe('ResumoRodada', () => {
  let component: ResumoRodada;
  let fixture: ComponentFixture<ResumoRodada>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ResumoRodada]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResumoRodada);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
