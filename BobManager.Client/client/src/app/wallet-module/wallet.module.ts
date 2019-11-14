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
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { RouterModule, Routes } from '@angular/router';
import { NgxPaginationModule } from 'ngx-pagination';

const routes: Routes = [
  { path: '', component: WalletListComponent },
  { path: 'addspending', component: AddWalletComponent },
  { path: ':page', component: WalletListComponent },

];

@NgModule({
  declarations: [WalletItemComponent, WalletListComponent, AddWalletComponent],
  imports: [
    CommonModule,
    FormsModule,
    CollapseModule.forRoot(),
    FontAwesomeModule,
    PaginationModule.forRoot(),
    NgxPaginationModule,
    RouterModule.forChild(routes)

  ],
  providers: [WalletService],
  exports: [WalletListComponent, WalletItemComponent, AddWalletComponent, RouterModule]
})
export class WalletModule { }



