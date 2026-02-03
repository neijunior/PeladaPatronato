import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { SidebarService } from '../../services/sidebar.service';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html'
})
export class Sidebar {

  constructor(public sidebar: SidebarService) {}

  menu = [
    { label: 'Dashboard', path: '/dashboard' },
    // { label: 'Participantes', path: '/participantes' },
    // { label: 'Rodadas', path: '/rodadas' },
    // { label: 'Estatísticas', path: '/estatisticas' },
    { label: 'Estatuto', path: '/documentos/estatuto/estatuto-financeiro' }
  ];
}
