import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-documento-viewer',
  standalone: true,
  templateUrl: './documento-viewer.html',
  imports: [CommonModule],
  styleUrls: ['./documento-viewer.css']
})
export class DocumentoViewer {

  pdfUrl!: SafeResourceUrl;

  constructor(
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer
  ) {
    const tipo = this.route.snapshot.paramMap.get('tipo');
    const arquivo = this.route.snapshot.paramMap.get('arquivo');

    const path = `/pdfs/${tipo}/${arquivo}.pdf`;


    this.pdfUrl = this.sanitizer.bypassSecurityTrustResourceUrl(path);
  }
}
