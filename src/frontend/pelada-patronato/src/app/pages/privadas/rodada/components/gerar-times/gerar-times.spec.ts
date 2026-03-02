import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerarTimes } from './gerar-times';

describe('GerarTimes', () => {
  let component: GerarTimes;
  let fixture: ComponentFixture<GerarTimes>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GerarTimes]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GerarTimes);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
