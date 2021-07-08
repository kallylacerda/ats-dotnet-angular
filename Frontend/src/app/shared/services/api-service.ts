import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PoNotificationService } from '@po-ui/ng-components';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

const BASE_URL = environment.urlApi;

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private readonly headers = {
    headers: { 'Content-Type': 'application/json' },
  };

  constructor(
    private httpClient: HttpClient,
    public poNotification: PoNotificationService
  ) {}

  public get(path: string): Observable<any> {
    return this.httpClient.get(BASE_URL + path).pipe(
      retry(1),

      catchError((e: any) => throwError(e))
    );
  }

  public post(path: string, body: any): Observable<any> {
    return this.httpClient
      .post(BASE_URL + path, JSON.stringify(body), this.headers)
      .pipe(
        retry(1),
        map(() =>
          this.poNotification.success('Operação realizada com sucesso')
        ),
        catchError((e: any) => {
          this.poNotification.error('Ocorreu um erro durante a operação');
          return throwError(e);
        })
      );
  }

  public put(path: string, body: any): Observable<any> {
    return this.httpClient
      .put(BASE_URL + path, JSON.stringify(body), this.headers)
      .pipe(
        retry(1),
        map(() =>
          this.poNotification.success('Operação realizada com sucesso')
        ),
        catchError((e: any) => {
          this.poNotification.error('Ocorreu um erro durante a operação');
          return throwError(e);
        })
      );
  }

  public delete(path: string): Observable<any> {
    return this.httpClient.delete(BASE_URL + path).pipe(
      retry(1),
      map(() => this.poNotification.success('Operação realizada com sucesso')),
      catchError((e: any) => {
        this.poNotification.error('Ocorreu um erro durante a operação');
        return throwError(e);
      })
    );
  }
}
