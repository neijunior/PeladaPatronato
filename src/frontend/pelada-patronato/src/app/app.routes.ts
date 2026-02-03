import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./layout/layout').then(m => m.Layout),
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard',
        loadComponent: () =>
          import('./pages/dashboard/dashboard').then(m => m.Dashboard)
      },
      { path: 'participantes',
        loadComponent: () =>
          import('./pages/participantes/participante-list/participante-list')
          .then(m => m.ParticipanteList)  
      },
      { path: 'participantes/novo',
        loadComponent: () =>
          import('./pages/participantes/participante-form/participante-form')
          .then(m => m.ParticipanteForm)
      },
      { path: 'rodadas',
        loadComponent: () =>
          import('./pages/rodadas/rodadas-list/rodadas-list')
          .then(m => m.RodadasList)  
      },
      { path: 'estatisticas',
        loadComponent: () =>
          import('./pages/estatisticas/estatisticas-list/estatisticas-list')
          .then(m => m.EstatisticasList)  
      },
      {
        path: 'documentos/:tipo/:arquivo',
        loadComponent: () =>
          import('./pages/documentos/viewer/documento-viewer')
            .then(m => m.DocumentoViewer)
      }
      // outras rotas...
    ]
  },
  { path: '**', redirectTo: '' }
];
