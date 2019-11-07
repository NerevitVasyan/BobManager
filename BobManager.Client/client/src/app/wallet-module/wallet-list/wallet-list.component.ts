import { Component, OnInit } from '@angular/core';
import { Wallet } from 'src/app/models/wallet';
import { WalletService } from 'src/app/services/wallet.service';

@Component({
  selector: 'app-wallet-list',
  templateUrl: './wallet-list.component.html',
  styleUrls: ['./wallet-list.component.css']
})
export class WalletListComponent implements OnInit {
  wallets: Wallet[];
  constructor(private walletService: WalletService) { }

  ngOnInit() {
    console.log("asd");
    
    this.walletService.getWallet().subscribe(res => {
      this.wallets = res.data;
    });
  }

}
