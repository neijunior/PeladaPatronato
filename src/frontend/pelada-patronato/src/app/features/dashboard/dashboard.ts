import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  template: `
    
  `,
  styles: [`
    .dashboard-container {
      display: flex;
      justify-content: center;
      align-items: center;
      height: 100%;
    }

    .dashboard-logo {
      max-width: 300px;
      width: 100%;
      opacity: 0.9;
    }
  `]
})
export class Dashboard {}
