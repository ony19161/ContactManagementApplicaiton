import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})

export class SignInComponent implements OnInit {
  model: any = {};
  showSignInForm = true;

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.showSuccess('Logged in successfully');
      },
      error => {
        this.alertify.showError(error);
      }
    );
  }

  showRegisterForm() {
    this.showSignInForm = false;
  }

  cancelRegisterMode(isShowSignInForm: boolean){
    this.showSignInForm = isShowSignInForm;
  }

}
