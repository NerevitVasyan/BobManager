import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { BaseService } from './base-http.service';
import { ApiRoutes } from '../consts/const';
import { Wallet } from '../models/wallet';

@Injectable({
  providedIn: 'root'
})
export class WalletService extends BaseService {

  getWallet(): Observable<any> {
    return this.get(ApiRoutes.wallet);
  }
  getWalletCount(): Observable<any> {
    return this.get(ApiRoutes.getWalletCount);
  }
  getWalletCategory(): Observable<any> {
    return this.get(ApiRoutes.getWalletCategory);
  }
  addWallet(item: Wallet): Observable<any> {
    console.log("hello")
    return this.post(ApiRoutes.addWallet, item);
  }
  getWalletForPage(pageIndex: number) {
    console.log("hello")
    return this.post(ApiRoutes.getWalletForPage, pageIndex);
  }
}


