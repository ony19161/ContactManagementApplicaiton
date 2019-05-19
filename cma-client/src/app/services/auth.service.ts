import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService  {
  isloggedin: boolean;
  baseURL = environment.apiUrl + 'auth/';

  constructor(private http: HttpClient)  {
    this.isloggedin = false;
   }

  login(model: any) {
    return this.http.post(this.baseURL + 'login', model)
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

  register(model: any) {
    return this.http.post(this.baseURL + 'register', model);
  }


}
