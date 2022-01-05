import { Coefficient } from './../models/coefficient';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class FibonacciServiceService {
  constructor(private http: HttpClient) {}

  getFromSql() {
    return this.http.get<Coefficient[]>(`${environment.API_URL}/Home/sql`);
  }

  getFromRedis() {
    return this.http.get<any>(`${environment.API_URL}/Home/redis`);
  }

  post(value: number) {
    return this.http.post<any>(`${environment.API_URL}/Home`, {
      value: value,
    });
  }
}
