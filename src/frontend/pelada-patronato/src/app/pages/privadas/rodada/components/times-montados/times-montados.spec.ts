import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimesMontados } from './times-montados';

describe('TimesMontados', () => {
  let component: TimesMontados;
  let fixture: ComponentFixture<TimesMontados>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TimesMontados]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TimesMontados);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
