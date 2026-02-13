import { Injectable, NgZone } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class IdleService {

    private timeoutId: any;
    private readonly idleTime = 10 * 60 * 1000; // 10 minutos

    private idleSubject = new Subject<void>();
    idle$ = this.idleSubject.asObservable();

    constructor(        
        private ngZone: NgZone
    ) { }

    stopWatching() {
        clearTimeout(this.timeoutId);
    }

    startWatching() {

        this.resetTimer();

        const events = ['mousemove', 'keydown', 'click', 'scroll'];

        events.forEach(event => {
            window.addEventListener(event, () => this.resetTimer());
        });
    }

    private resetTimer() {
        clearTimeout(this.timeoutId);

        this.ngZone.runOutsideAngular(() => {
            this.timeoutId = setTimeout(() => {
                this.ngZone.run(() => {
                    this.idleSubject.next();
                });
            }, this.idleTime);
        });
    }
}
