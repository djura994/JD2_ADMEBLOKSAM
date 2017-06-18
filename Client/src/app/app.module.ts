import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { AccomodationComponent } from './accomodationsComponent/accomodations.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { AuthService } from './services/authenticationService'
import { UserService } from './services/userService';
import { LoggedInGuard } from './loggedInGuard'
import { LogInService } from './services/logInService'

const Routes = [
  { path: 'accomodations', component: AccomodationComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    AccomodationComponent
  ],

  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(Routes)
  ],

  providers: [AuthService, LoggedInGuard, UserService, LogInService],//!LoggedInGuard also has to be included in providers!
  bootstrap: [AppComponent]
})

export class AppModule { }
