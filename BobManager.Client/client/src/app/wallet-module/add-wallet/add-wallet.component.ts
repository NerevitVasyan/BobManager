import { Component, OnInit, ɵLocaleDataIndex } from '@angular/core';
import { WalletCategory } from 'src/app/models/wallet-category';
import { WalletService } from 'src/app/services/wallet.service';
import { Wallet } from 'src/app/models/wallet';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-wallet',
  templateUrl: './add-wallet.component.html',
  styleUrls: ['./add-wallet.component.css']
})
export class AddWalletComponent implements OnInit {
  walletsCategories: WalletCategory[];
  wallet: Wallet;
  date: number;
  category: string;
  constructor(private walletService: WalletService,private router: Router) { }

  ngOnInit() {
    this.wallet = new Wallet();
    this.date = Date.now();
    this.wallet.userId = "lol";
    this.wallet.date=new Date(this.date);
    console.log(this.wallet.date);
    this.walletService.getWalletCategory().subscribe(res => {
      this.walletsCategories = res.data;

    });

  }
  addClick() {
    this.walletsCategories.forEach(element => {
      if (element.name == this.category) {
        this.wallet.spendingCategory = element;
      }
    });
    this.walletService.addWallet(this.wallet).subscribe(x => { })
    this.router.navigate(['/wallet/1']);
  }
  cancelClick(){
    this.router.navigate(['/wallet/1']);
  }


}
