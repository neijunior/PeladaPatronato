import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DocumentoViewer } from './documento-viewer';



describe('DocumentoViewer', () => {
  let component: DocumentoViewer;
  let fixture: ComponentFixture<DocumentoViewer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DocumentoViewer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DocumentoViewer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
