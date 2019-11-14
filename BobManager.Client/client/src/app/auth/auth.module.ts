import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent,

  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports:[],
  providers: []
})
export class AuthModule { }
