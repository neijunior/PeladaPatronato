import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    // se usar HttpClient, animações etc, adicione providers conforme necessário
    // ex: provideHttpClient(), provideAnimations(), ...
  ]
};
