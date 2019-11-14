import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { WalletModule } from './wallet-module/wallet.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [{
      path: '',
      component: HomeComponent
   },
   {
      path: 'wallet',
      loadChildren: () => import('./wallet-module/wallet.module').then(m => m.WalletModule)
   }
];
import { ToDoModule } from './to-do-module/to-do.module';

import { AppRoutingModule } from './app-routing.module';
import { AuthModule } from './auth/auth.module';

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
      RouterModule.forRoot(routes),
      CollapseModule.forRoot(),
      AppRoutingModule,
      AuthModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }