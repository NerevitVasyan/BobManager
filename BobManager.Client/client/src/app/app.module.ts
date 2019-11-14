import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { WalletModule } from './wallet-module/wallet.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


const routes: Routes = [{
      path: '',
      component: HomeComponent
   },
   {
      path: 'wallet',
      loadChildren: () => import('./wallet-module/wallet.module').then(m => m.WalletModule)
   }
];

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      HeaderComponent,
      FooterComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      HttpClientModule,
      PaginationModule.forRoot(),
      RouterModule.forRoot(routes)
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
