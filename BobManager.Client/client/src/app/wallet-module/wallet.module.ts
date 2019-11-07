import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WalletItemComponent } from './wallet-item/wallet-item.component';
import { WalletService } from '../services/wallet.service';
import { HttpClientModule } from '@angular/common/http';
import { WalletListComponent } from './wallet-list/wallet-list.component';
import { AddWalletComponent } from './add-wallet/add-wallet.component';
import { FormsModule } from '@angular/forms'
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';









@NgModule({
  declarations: [WalletItemComponent, WalletListComponent, AddWalletComponent],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    CollapseModule.forRoot(),
    BrowserAnimationsModule,
    FontAwesomeModule,

  ],
  providers: [WalletService],
  exports: [WalletListComponent, WalletItemComponent, AddWalletComponent]
})
export class WalletModule { }



