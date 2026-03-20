import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth-guard';
import { Times } from './features/rodada/pages/times/times';
import { Participantes } from './features/rodada/pages/participantes/participantes';
import { Partidas } from './features/rodada/pages/partidas/partidas';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./layout/layout').then(m => m.Layout),
    children: [
      { path: 'login', loadComponent: () => import('./public/auth/login/login').then(m => m.Login) },
      {
        path: '',
        loadComponent: () =>
          import('./public/home/home')
            .then(m => m.Home)
      },
      { path: 'sobre', loadComponent: () => import('./public/sobre/sobre').then(m => m.Sobre) },
      {
        path: 'dashboard', canActivate: [authGuard], loadComponent: () => import('./features/dashboard/dashboard').then(m => m.Dashboard)
      },
      {
        path: 'participantes', canActivate: [authGuard],
        loadComponent: () =>
          import('./features/participantes/pages/participante-list/participante-list')
            .then(m => m.ParticipanteList)
      },
      {
        path: 'participantes/novo', canActivate: [authGuard],
        loadComponent: () =>
          import('./features/participantes/pages/participante-form/participante-form')
            .then(m => m.ParticipanteForm)
      },
      {
        path: 'rodadas',
        canActivate: [authGuard],
        children: [
          {
            path: '',
            loadComponent: () =>
              import('./features/rodada/pages/rodada-list/rodada-list')
                .then(m => m.RodadaList)
          },
          {
            path: ':id',
            loadComponent: () =>
              import('./features/rodada/pages/rodada-detalhe/rodada-detalhe')
                .then(m => m.RodadaDetalhe),
            children: [
              { path: '', redirectTo: 'participantes', pathMatch: 'full' },
               { path: 'participantes', component: Participantes },
               { path: 'times', component: Times },
               { path: 'partidas', component: Partidas },
              // { path: 'resultados', component: ResultadosComponent }
            ]
          },
          { path: '', redirectTo: 'ranking', pathMatch: 'full' } // opcional: default para ranking
        ]
      },
      {
        path: 'estatisticas',
        canActivate: [authGuard],
        children: [
          {
            path: 'ranking',
            loadComponent: () =>
              import('./features/estatisticas/ranking-semestral/ranking-semestral')
                .then(m => m.RankingSemestral)
          },
          {
            path: 'consulta',
            loadComponent: () =>
              import('./features/estatisticas/consulta-geral/consulta-geral')
                .then(m => m.ConsultaGeral)
          },
          { path: '', redirectTo: 'ranking', pathMatch: 'full' } // opcional: default para ranking
        ]
      },
      {
        path: 'documentos/:tipo/:arquivo', canActivate: [authGuard],
        loadComponent: () =>
          import('./public/documentos/viewer/documento-viewer')
            .then(m => m.DocumentoViewer)
      }
    ]
  },
  { path: '**', redirectTo: '' }
];
