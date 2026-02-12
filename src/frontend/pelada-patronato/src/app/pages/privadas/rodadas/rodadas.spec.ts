import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Rodadas } from './rodadas';

describe('Rodadas', () => {
  let component: Rodadas;
  let fixture: ComponentFixture<Rodadas>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Rodadas]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Rodadas);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
