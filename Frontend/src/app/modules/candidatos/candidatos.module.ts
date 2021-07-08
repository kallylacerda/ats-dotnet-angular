import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PoModule } from '@po-ui/ng-components';
import { CandidatosRoutingModule } from './candidatos-routing.module';
import { CandidatosComponent } from './pages/candidatos.component';
import { CreateEditCandidatoComponent } from './pages/create-edit-candidato/create-edit-candidato.component';
import { ListDeleteCandidatosComponent } from './pages/list-delete-candidatos/list-delete-candidatos.component';

@NgModule({
  declarations: [
    ListDeleteCandidatosComponent,
    CandidatosComponent,
    CreateEditCandidatoComponent,
  ],
  imports: [
    CommonModule,
    CandidatosRoutingModule,
    PoModule,
    ReactiveFormsModule,
    FormsModule,
  ],
})
export class CandidatosModule {}
