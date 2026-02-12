import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RodadasList } from './rodadas-list';

describe('RodadasList', () => {
  let component: RodadasList;
  let fixture: ComponentFixture<RodadasList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RodadasList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RodadasList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
