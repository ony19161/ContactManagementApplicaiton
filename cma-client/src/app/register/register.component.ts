import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../services/auth.service';

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

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(
    next => {
      this.registrationCompleted = true;
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(true);
    console.log('canceled');
  }

}
