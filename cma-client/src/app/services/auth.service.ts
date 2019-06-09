import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService  {
  isloggedin: boolean;
  baseURL = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  user = new User();

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

  setLoggedInUser(token) {
    this.decodedToken = this.jwtHelper.decodeToken(token);
    this.user.id = this.decodedToken.nameid;
    this.user.name = this.decodedToken.unique_name;
    this.user.email = this.decodedToken.emai;
  }

  register(model: any) {
    return this.http.post(this.baseURL + 'register', model);
  }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }


}
