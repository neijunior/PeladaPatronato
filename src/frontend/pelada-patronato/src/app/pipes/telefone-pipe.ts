import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'telefone'
})
export class TelefonePipe implements PipeTransform {

  transform(value: string | null | undefined): string {
    if (!value) return '';

    // Remove tudo que não é número
    const numeros = value.replace(/\D/g, '');

    // Formato: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX
    if (numeros.length === 10) {
      return numeros.replace(/(\d{2})(\d{4})(\d{4})/, '($1) $2-$3');
    } else if (numeros.length === 11) {
      return numeros.replace(/(\d{2})(\d{5})(\d{4})/, '($1) $2-$3');
    } else {
      return value; // retorna como veio se não for 10 ou 11 dígitos
    }
  }

}
