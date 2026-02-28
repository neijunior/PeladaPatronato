import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth-guard';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./layout/layout').then(m => m.Layout),
    children: [
      { path: 'login', loadComponent: () => import('./pages/auth/login/login').then(m => m.Login) },
      {
        path: '',
        loadComponent: () =>
          import('./pages/publicas/home/home')
            .then(m => m.Home)
      },
      { path: 'sobre', loadComponent: () => import('./pages/publicas/sobre/sobre').then(m => m.Sobre) },
      {
        path: 'dashboard', canActivate: [authGuard], loadComponent: () => import('./pages/privadas/dashboard/dashboard').then(m => m.Dashboard)
      },
      {
        path: 'participantes', canActivate: [authGuard],
        loadComponent: () =>
          import('./pages/privadas/participantes/participante-list/participante-list')
            .then(m => m.ParticipanteList)
      },
      {
        path: 'participantes/novo', canActivate: [authGuard],
        loadComponent: () =>
          import('./pages/privadas/participantes/participante-form/participante-form')
            .then(m => m.ParticipanteForm)
      },
      {
        path: 'rodadas', canActivate: [authGuard],
        loadComponent: () =>
          import('./pages/privadas/rodadas/rodadas-list/rodadas-list')
            .then(m => m.RodadasList)
      },
      {
        path: 'estatisticas',
        canActivate: [authGuard],
        children: [
          {
            path: 'ranking',  // /estatisticas/ranking
            loadComponent: () =>
              import('./pages/privadas/estatisticas/ranking-semestral/ranking-semestral')
                .then(m => m.RankingSemestral)
          },
          {
            path: 'consulta', // /estatisticas/consulta
            loadComponent: () =>
              import('./pages/privadas/estatisticas/consulta-geral/consulta-geral')
                .then(m => m.ConsultaGeral)
          },
          { path: '', redirectTo: 'ranking', pathMatch: 'full' } // opcional: default para ranking
        ]
      },
      {
        path: 'documentos/:tipo/:arquivo', canActivate: [authGuard],
        loadComponent: () =>
          import('./pages/publicas/documentos/viewer/documento-viewer')
            .then(m => m.DocumentoViewer)
      }
    ]
  },
  { path: '**', redirectTo: '' }
];
