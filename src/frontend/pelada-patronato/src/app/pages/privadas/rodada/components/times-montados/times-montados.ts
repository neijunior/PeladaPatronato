import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-times-montados',
  imports: [CommonModule],
  templateUrl: './times-montados.html',
  styleUrl: './times-montados.css',
})
export class TimesMontados {
  @Input() times: any[] = [];
  @Input() obterNomeTime!: (id: string) => string | undefined;
  @Input() obterNomeParticipante!: (id: string) => string | undefined;
}
