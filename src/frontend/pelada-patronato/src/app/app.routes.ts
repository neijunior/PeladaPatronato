// src/app/app.routes.ts
import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'participantes', pathMatch: 'full' },

  {
    path: 'participantes',
    loadComponent: () =>
      import('./features/participantes/participante-list/participante-list')  // sem .component.ts
        .then(m => m.ParticipanteList),             // nome da classe
  },

  {
    path: 'participantes/novo',
    loadComponent: () =>
      import('./features/participantes/participante-form/participante-form')  // sem .component
        .then(m => m.ParticipanteForm),
  },

  { path: '**', redirectTo: 'participantes' }
];
