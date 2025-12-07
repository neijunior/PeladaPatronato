import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html'
})
export class Sidebar {
  menu = [
    { label: 'Dashboard', path: '/dashboard' },
    { label: 'Participantes', path: '/participantes' },
    { label: 'Rodadas', path: '/rodada' },
    { label: 'Estatatísticas', path: '/estatatisticas' },
    // futuramente: outras opções vindas de backend/permissões
  ];
}
