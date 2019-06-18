import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private authService: AuthService,
    private alertify: AlertifyService) {

  }

  canActivate():  boolean {
    if (this.authService.isLoggedIn()) {
      return true;
    }

    this.alertify.showError('You shall not pass!!!');
    this.router.navigate(['/login']);
    return false;
  }
}
