import { CreateEditCandidatoComponent } from './pages/create-edit-candidato/create-edit-candidato.component';
import { CandidatosComponent } from './pages/candidatos.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListDeleteCandidatosComponent } from './pages/list-delete-candidatos/list-delete-candidatos.component';

const routes: Routes = [
  {
    path: '',
    component: CandidatosComponent,
    children: [
      {
        path: '',
        component: ListDeleteCandidatosComponent,
      },
      {
        path: 'add',
        component: CreateEditCandidatoComponent,
      },
      {
        path: ':id',
        component: CreateEditCandidatoComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CandidatosRoutingModule {}
