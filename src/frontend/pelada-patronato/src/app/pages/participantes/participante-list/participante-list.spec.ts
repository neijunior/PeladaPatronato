import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParticipanteList } from './participante-list';

describe('ParticipanteList', () => {
  let component: ParticipanteList;
  let fixture: ComponentFixture<ParticipanteList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParticipanteList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParticipanteList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
