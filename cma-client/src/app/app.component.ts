import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Contact Management Appplication';

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }
}
