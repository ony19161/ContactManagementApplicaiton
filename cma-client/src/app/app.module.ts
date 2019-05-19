import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule, PaginationModule } from 'ngx-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthService } from './services/auth.service';
import { SignInComponent } from './sign-in/sign-in.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { CategoryComponent } from './category/category.component';
import { ContactComponent } from './contact/contact.component';
import { NavComponent } from './nav/nav.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { CategoryService } from './services/category.service';

@NgModule({
   declarations: [
      AppComponent,
      SignInComponent,
      HomeComponent,
      RegisterComponent,
      CategoryComponent,
      ContactComponent,
      NavComponent,
      UserProfileComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      PaginationModule.forRoot()
   ],
   providers: [
      AuthService,
      CategoryService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
