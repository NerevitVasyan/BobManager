import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WalletItemComponent } from './wallet-item/wallet-item.component';
import { WalletService } from '../services/wallet.service';
import { HttpClientModule } from '@angular/common/http';
import { WalletListComponent } from './wallet-list/wallet-list.component';



@NgModule({
  declarations: [WalletItemComponent, WalletListComponent],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [WalletService],
  exports:[WalletListComponent,WalletItemComponent]
})
export class WalletModule { }



