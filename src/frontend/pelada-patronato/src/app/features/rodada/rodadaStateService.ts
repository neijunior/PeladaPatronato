import { Injectable, signal } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class RodadaStateService {
    private atualizadoSignal = signal(0);

    atualizado = this.atualizadoSignal.asReadonly();

    notificar() {
        this.atualizadoSignal.update(v => v + 1);
    }
}
