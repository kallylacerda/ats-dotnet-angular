import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../../shared/services/api-service';

@Injectable({
  providedIn: 'root',
})
export class EnderecoService {
  private readonly API_MUNICIPIOS = '/municipios';
  private readonly API_UFS = '/ufs';

  constructor(private apiService: ApiService) {}

  public getAllUfs(): Observable<any> {
    return this.apiService.get(this.API_UFS);
  }

  public getAllMunicipios(): Observable<any> {
    return this.apiService.get(this.API_MUNICIPIOS);
  }

  public getMunicipiosByUfId(ufId: string): Observable<any> {
    return this.apiService.get(`${this.API_MUNICIPIOS}?ufId=${ufId}`);
  }
}
