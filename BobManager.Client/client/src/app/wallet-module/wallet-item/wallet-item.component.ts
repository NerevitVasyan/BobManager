import { Component, OnInit, Input } from '@angular/core';
import { Wallet } from 'src/app/models/wallet';

@Component({
  selector: 'app-wallet-item',
  templateUrl: './wallet-item.component.html',
  styleUrls: ['./wallet-item.component.css']
})
export class WalletItemComponent implements OnInit {
  @Input() item: Wallet;
  constructor() { }

  ngOnInit() {
    
  }

}
