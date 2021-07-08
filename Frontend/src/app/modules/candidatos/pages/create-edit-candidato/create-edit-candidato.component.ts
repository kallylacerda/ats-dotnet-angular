import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PoSelectOption } from '@po-ui/ng-components';
import { Subscription } from 'rxjs';
import { Candidato } from './../../../../core/models/candidato';
import { Municipio, Uf } from './../../../../core/models/endereco';
import { CandidatoService } from './../../../../core/services/candidato.service';
import { EnderecoService } from './../../../../core/services/endereco.service';

@Component({
  selector: 'app-create-edit-candidato',
  templateUrl: './create-edit-candidato.component.html',
  styleUrls: ['./create-edit-candidato.component.scss'],
})
export class CreateEditCandidatoComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public ufsOptions: PoSelectOption[] = [];
  public municipiosOptions: PoSelectOption[] = [];
  public maxDate: Date = new Date();
  public pageAction: string = 'Adicionar';
  private subscriptions: Subscription = new Subscription();

  constructor(
    private formBuilder: FormBuilder,
    private enderecoService: EnderecoService,
    private candidatoService: CandidatoService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.formBuilder.group({
      nomeCompleto: ['', Validators.required],
      email: ['', Validators.required],
      cpf: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      telefone: [''],
      descricao: [''],
      endereco: this.formBuilder.group({
        estadoId: [''],
        municipioId: ['', Validators.required],
        cep: ['', Validators.required],
        logradouro: ['', Validators.required],
        numero: [''],
      }),
    });
  }

  ngOnInit() {
    this.subscriptions.add(this.getUfs());
    const idCandidato = this.route.snapshot.params?.id;
    if (idCandidato) {
      this.pageAction = 'Alterar';
      this.subscriptions.add(this.getCandidato(idCandidato));
    }
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  private getCandidato(id: string): Subscription {
    return this.candidatoService.get(id).subscribe((candidato: Candidato) => {
      this.updateForm({
        ...candidato,
        dataNascimento: candidato.dataNascimento.split('T')[0],
      });
    });
  }

  private getUfs(): Subscription {
    return this.enderecoService.getAllUfs().subscribe((ufs: Uf[]) => {
      ufs.forEach((uf: Uf) =>
        this.ufsOptions.push({
          label: `${uf.sigla} - ${uf.nome}`,
          value: uf.id,
        })
      );
    });
  }

  private getMunicipios(): Subscription {
    const ufId = this.form.get('endereco')?.get('estadoId')?.value;
    return this.enderecoService
      .getMunicipiosByUfId(ufId)
      .subscribe((municipios: Municipio[]) => {
        this.municipiosOptions = [];
        municipios.forEach((municipio: Municipio) =>
          this.municipiosOptions.push({
            label: municipio.nome,
            value: municipio.id,
          })
        );
      });
  }

  private updateForm(candidato: Candidato): void {
    this.form.patchValue({
      nomeCompleto: candidato.nomeCompleto,
      email: candidato.email,
      cpf: candidato.cpf,
      dataNascimento: candidato.dataNascimento,
      telefone: candidato.telefone,
      descricao: candidato.descricao,
      endereco: {
        estadoId: candidato.endereco?.municipio.uf.id,
        municipioId: candidato.endereco?.municipio.id,
        cep: candidato.endereco?.cep,
        logradouro: candidato.endereco?.logradouro,
        numero: candidato.endereco?.numero,
      },
    });
    this.subscriptions.add(this.getMunicipios());
  }

  public ufChange(): void {
    this.form.get('endereco')?.get('municipioId')?.patchValue('');
    this.subscriptions.add(this.getMunicipios());
  }

  public cancel(): void {
    this.router.navigate(['candidatos']);
  }

  public save(): void {
    if (this.form.valid) {
      const candidato: Candidato = this.form.getRawValue();
      this.subscriptions.add(
        this.candidatoService.create(candidato).subscribe(() => {
          this.form.reset();
        })
      );
    }
  }
}
