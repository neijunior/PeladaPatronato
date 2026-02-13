import { Component, OnDestroy, OnInit } from '@angular/core';
import { SidebarService } from '../services/sidebar.service';
import { RouterOutlet } from "@angular/router";
import { Sidebar } from './sidebar/sidebar';
import { AuthService } from '../services/auth.service';
import { CommonModule } from '@angular/common';
import { IdleService } from '../services/idle.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [Sidebar, RouterOutlet, CommonModule],
  templateUrl: './layout.html'
})
export class Layout implements OnInit, OnDestroy {

  private subscription!: Subscription;

  constructor(public sidebar: SidebarService,
    public authService: AuthService,
    private idleService: IdleService
  ) {

  }
  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
    this.idleService.stopWatching();
  }

  ngOnInit(): void {
    this.idleService.startWatching();
    this.subscription = this.idleService.idle$.subscribe(() => {
      this.authService.logout();
    });
  }

  logout() {
    this.authService.logout();
  }
}
