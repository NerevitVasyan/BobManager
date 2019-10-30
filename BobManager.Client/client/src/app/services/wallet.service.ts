import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class WalletService {

  BASE_API: string = 'https://localhost:44339/api/';

  constructor(private http: HttpClient) { }
  getWallet(): Observable<any> {
    return this.http.get(this.BASE_API + 'wallet');
  }
}


