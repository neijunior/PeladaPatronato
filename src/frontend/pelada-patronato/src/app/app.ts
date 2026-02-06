import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TelefonePipe } from './pipes/telefone-pipe';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, TelefonePipe],
   template: `<router-outlet></router-outlet>`,  
  styleUrls: ['./app.css']  // ou .css conforme seu setup,
})

export class App {}
