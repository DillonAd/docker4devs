import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../environments/environment';
import { Value } from './value';

@Injectable({
  providedIn: 'root'
})
export class ValueService {

  private url: string = environment.baseUrl + '/api/values/';

  constructor(private http: HttpClient) { }

  getValues(): Observable<string[]> {
    return this.http.get<string[]>(this.url)
  }

  addValue(value: Value): Observable<any> {
    return this.http.post(this.url, value);
  }
}
