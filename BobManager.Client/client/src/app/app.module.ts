import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

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
      HttpClientModule,
      AppRoutingModule,
      AuthModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
