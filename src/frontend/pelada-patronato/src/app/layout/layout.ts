import { Component } from '@angular/core';
import { SidebarService } from '../services/sidebar.service';
import { RouterOutlet } from "@angular/router";
import { Sidebar } from './sidebar/sidebar';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [Sidebar, RouterOutlet],
  templateUrl: './layout.html'
})
export class Layout {
  constructor(public sidebar: SidebarService) {}
}
