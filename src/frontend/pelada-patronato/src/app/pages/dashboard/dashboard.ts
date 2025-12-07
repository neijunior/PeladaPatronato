import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  template: `<div class="p-6"><h1 class="text-2xl font-bold">Dashboard</h1>
    <p>Bem‑vindo ao painel inicial.</p>
  </div>`
})
export class Dashboard {}
