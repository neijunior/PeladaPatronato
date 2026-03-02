import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RodadaCreate } from './rodada-create';

describe('RodadaCreate', () => {
  let component: RodadaCreate;
  let fixture: ComponentFixture<RodadaCreate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RodadaCreate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RodadaCreate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
