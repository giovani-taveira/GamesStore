import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { GameCardComponent } from './game-card/game-card.component';
import { CardGameDataService } from './_services/cardGame.data-service';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserLoginDataService } from './_services/user-login';
import { RegisterUserComponent } from './register-user/register-user.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GameCardComponent,
    UserLoginComponent,
    RegisterUserComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'games', component: GameCardComponent },
      { path: 'signup', component: RegisterUserComponent },
      { path: 'login', component: UserLoginComponent },
      { path: 'home', component: NavMenuComponent },
    ])
  ],
  providers: [CardGameDataService, UserLoginComponent, UserLoginDataService, RegisterUserComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
