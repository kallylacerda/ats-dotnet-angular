import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import {
  PoModalAction,
  PoModalComponent,
  PoTableColumn,
} from '@po-ui/ng-components';
import { Subscription } from 'rxjs';
import { Candidato } from '../../../../core/models/candidato';
import { CandidatoService } from '../../../../core/services/candidato.service';

@Component({
  selector: 'app-list-delete-candidatos',
  templateUrl: './list-delete-candidatos.component.html',
  styleUrls: ['./list-delete-candidatos.component.scss'],
})
export class ListDeleteCandidatosComponent implements OnInit, OnDestroy {
  @ViewChild(PoModalComponent, { static: true }) poModal:
    | PoModalComponent
    | undefined;

  public columns: PoTableColumn[] = [
    { property: 'id', label: 'Id' },
    { property: 'nomeCompleto', label: 'Nome' },
    { property: 'email', label: 'Email' },
    { property: 'telefone', label: 'Telefone' },
    {
      property: 'dataNascimento',
      label: 'Data de Nascimento',
      type: 'cellTemplate',
    },
    { property: 'createdAt', label: 'Data de Inclusão', type: 'cellTemplate' },
    { property: 'acoes', label: ' ', type: 'cellTemplate' },
  ];

  public items: Array<Candidato> = [];

  public idCandidatoToDelete: string = '';

  private subscriptions: Subscription = new Subscription();

  public confirm: PoModalAction = {
    action: () => {
      this.deleteItem(this.idCandidatoToDelete);
      this.poModal?.close();
    },
    label: 'Sim',
    danger: true,
  };

  public close: PoModalAction = {
    action: () => {
      this.idCandidatoToDelete = '';
      this.poModal?.close();
    },
    label: 'Não',
  };

  constructor(
    private candidatoService: CandidatoService,
    public router: Router
  ) {}

  ngOnInit() {
    this.subscriptions.add(this.getAllCandidatos());
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  private getAllCandidatos(): void {
    this.subscriptions.add(
      this.candidatoService
        .getAll()
        .subscribe((res: Candidato[]) => (this.items = res))
    );
  }

  public navigateToAdd(): void {
    this.router.navigate(['candidatos', 'add']);
  }

  public navigateToEdit(id: string): void {
    this.router.navigate(['candidatos', id]);
  }

  public openDeleteConfirmation(idCandidato: string): void {
    this.idCandidatoToDelete = idCandidato;
    this.poModal?.open();
  }

  public deleteItem(id: string): void {
    if (id) {
      this.subscriptions.add(
        this.candidatoService.delete(id).subscribe((_) => {
          this.getAllCandidatos();
          this.idCandidatoToDelete = '';
        })
      );
    }
  }
}
