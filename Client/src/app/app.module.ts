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
import { AccomodationService } from './services/accomodation.service';
import { RoomsService } from './services/room.service';
import { AccomodationTypeService } from './services/accomodationType.service';
import { PlaceService } from './services/place.service';
import { RoomsComponent } from './roomsComponent/rooms.component';
import { CommentComponent } from './CommentComponent/comment.component';
import { CommentService } from './services/comment.service';

const Routes = [
  { path: 'accomodations', component: AccomodationComponent },
  { path: 'rooms', component: RoomsComponent },
  {path: 'login', component: AppComponent},
  {path: 'comment', component: CommentComponent }

];

@NgModule({
  declarations: [
    AppComponent,
    RoomsComponent,
    AccomodationComponent,
    CommentComponent
  ],

  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(Routes)
  ],

  providers: [AuthService, LoggedInGuard, UserService, LogInService, AccomodationService,RoomsService, AccomodationTypeService, PlaceService, CommentService],//!LoggedInGuard also has to be included in providers!
  bootstrap: [AppComponent]
})

export class AppModule { }
