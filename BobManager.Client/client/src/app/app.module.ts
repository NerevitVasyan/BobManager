import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { WalletModule } from './wallet-module/wallet.module';


@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      HeaderComponent,
      FooterComponent
   ],
   imports: [
      BrowserModule,
      WalletModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
