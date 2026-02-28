import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { SidebarService } from '../../services/sidebar.service';
import { AuthService } from '../../services/auth.service';

interface MenuItem {
  label: string;
  path?: string;
  requiresAuth?: boolean;
  children?: MenuItem[];
  expanded?: boolean 
}

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html'
})
export class Sidebar {

  constructor(public sidebar: SidebarService, private auth: AuthService) { }

  private allMenu: MenuItem[] = [
    { label: 'Home', path: '/' },
    { label: 'Dashboard', path: '/dashboard', requiresAuth: true },
    { label: 'Participantes', path: '/participantes', requiresAuth: true },

    // Estatísticas com submenu
    {
      label: 'Estatísticas',
      requiresAuth: true,
      expanded: false,
      children: [
        { label: 'Ranking Semestral', path: '/estatisticas/ranking' },
        { label: 'Consulta Livre', path: '/estatisticas/consulta' }
      ]
    },

    { label: 'Estatuto', path: '/documentos/estatuto/estatuto-financeiro' },
    { label: 'Sobre', path: '/sobre' },
  ];

  get menu(): MenuItem[] {
    return this.allMenu.filter(item =>
      !item.requiresAuth || this.auth.isAuthenticated()
    );
  }
}
