import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RodadaService } from '../rodada.service';
import { SelecionarParticipantes } from "../components/selecionar-participantes/selecionar-participantes";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-rodada-create',
  templateUrl: './rodada-create.html',
  styleUrls: ['./rodada-create.css'],
  imports: [SelecionarParticipantes, CommonModule, ReactiveFormsModule   ]
})
export class RodadaCreate implements OnInit {

  form!: FormGroup;

  loading = false;
  erroApi = false;
  erroParticipantes = false;

  participantesSelecionados: string[] = [];

  constructor(
    private fb: FormBuilder,
    private rodadaService: RodadaService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      data: [this.getHojeFormatado(), Validators.required],
      local: ['', Validators.required]
    });
  }

  /**
   * Recebe os participantes do componente filho
   */
  onParticipantesSelecionados(ids: string[]): void {
    this.participantesSelecionados = ids;
    this.erroParticipantes = false;
  }

  /**
   * Botão principal
   */
  criarRodada(): void {

    this.erroApi = false;
    this.erroParticipantes = false;

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    if (this.participantesSelecionados.length < 4) {
      this.erroParticipantes = true;
      return;
    }

    const dto = {
      data: this.form.value.data,
      local: this.form.value.local,
      participantesIds: this.participantesSelecionados
    };

    this.loading = true;

    this.rodadaService.criarRodada(dto).subscribe({
      next: (rodadaId: string) => {
        this.loading = false;

        // Navega para próxima etapa (criar times)
        this.router.navigate(['/rodada', rodadaId, 'times']);
      },
      error: (err) => {
        console.error('Erro ao criar rodada', err);
        this.loading = false;
        this.erroApi = true;
      }
    });
  }

  /**
   * Retorna data de hoje no formato yyyy-MM-dd
   */
  private getHojeFormatado(): string {
    const hoje = new Date();
    const ano = hoje.getFullYear();
    const mes = String(hoje.getMonth() + 1).padStart(2, '0');
    const dia = String(hoje.getDate()).padStart(2, '0');
    return `${ano}-${mes}-${dia}`;
  }

}