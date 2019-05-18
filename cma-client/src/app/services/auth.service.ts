import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './BaseService';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService  {
  isloggedin: boolean;
  baseURL = 'http://localhost:50376/api/auth/login';

  constructor(private http: HttpClient)  {
    this.isloggedin = false;
   }

  login(model: any) {
    return this.http.post(this.baseURL, model)
    .pipe(
      map((response: any) => {

        const data = response;

        if (data) {
          this.isloggedin = true;
          localStorage.setItem('token', data.token);
        }

      })
    );
  }


}
