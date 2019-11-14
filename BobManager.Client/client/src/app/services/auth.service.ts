import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { RegisterDto } from '../models/register.model';
import { LoginDto } from '../models/login.model';
import { BaseService } from './base-http.service';
import { AuthRoutes } from './../consts/const'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  private jwtHelper = new JwtHelperService();
  decodedToken: any;

  register(user: RegisterDto): Observable<any> {
    return this.post(AuthRoutes.register, user);
  }

  login(user: LoginDto): Observable<any>  {
     return this.post(AuthRoutes.login, user);
  }

  private getTokenPayload(): string {
    return this.jwtHelper.decodeToken(localStorage.getItem('token'));
  }
}
