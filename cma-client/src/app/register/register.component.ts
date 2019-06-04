import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Input() showRegisterForm: any;
  @Output() cancelRegister = new EventEmitter();
  registrationCompleted = false;

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(
    next => {
      this.registrationCompleted = true;
      this.alertify.showSuccess('Registration successful');
    }, error => {
      this.alertify.showError(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(true);
    console.log('canceled');
  }

}
