import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RodadaTimes } from './rodada-times';

describe('RodadaTimes', () => {
  let component: RodadaTimes;
  let fixture: ComponentFixture<RodadaTimes>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RodadaTimes]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RodadaTimes);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
