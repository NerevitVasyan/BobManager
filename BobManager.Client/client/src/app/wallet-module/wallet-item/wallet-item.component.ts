import { Component, OnInit, Input } from '@angular/core';
import { Wallet } from 'src/app/models/wallet';
import { faChevronDown } from '@fortawesome/free-solid-svg-icons';
import { faChevronUp } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-wallet-item',
  templateUrl: './wallet-item.component.html',
  styleUrls: ['./wallet-item.component.css']
})
export class WalletItemComponent implements OnInit {
  faChevronDown=faChevronDown;
  faChevronUp=faChevronUp;
  isCollapsed = true;
  @Input() item: Wallet;

  constructor() { }

  ngOnInit() {
    
  }
  

}
