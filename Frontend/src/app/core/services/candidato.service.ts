import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { deleteEmptyProp } from 'src/app/shared/utils/empty-prop';
import { ApiService } from 'src/app/shared/services/api-service';
import { Candidato } from 'src/app/core/models/candidato';

@Injectable({
  providedIn: 'root',
})
export class CandidatoService {
  private readonly API_CANDIDATOS = '/candidatos';

  constructor(private apiService: ApiService) {}

  public getAll(): Observable<Array<Candidato>> {
    return this.apiService.get(this.API_CANDIDATOS);
  }

  public get(idCandidato: string): Observable<Candidato> {
    return this.apiService.get(`${this.API_CANDIDATOS}/${idCandidato}`);
  }

  public create(candidatoObj: Candidato): Observable<void> {
    const candidato: any = deleteEmptyProp(candidatoObj);
    return this.apiService.post(this.API_CANDIDATOS, candidato);
  }

  public edit(candidatoObj: Candidato): Observable<void> {
    return this.apiService.put(this.API_CANDIDATOS, candidatoObj);
  }

  public delete(idCandidato: string): Observable<void> {
    return this.apiService.delete(`${this.API_CANDIDATOS}/${idCandidato}`);
  }
}
