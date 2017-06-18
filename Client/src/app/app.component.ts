import { Component } from '@angular/core';
import {AuthService} from './services/authenticationService';
import {UserService} from './services/userService';
import {User} from './models/user.model';
import {LogInService} from './services/logInService';
import {Login} from './models/logIn.model';
import {NgForm} from '@angular/forms';

import {
Router,
ActivatedRoute
}
from '@angular/router';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Login';

  constructor(private loginService: LogInService, private authService: AuthService, private router: Router, private activatedRoute: ActivatedRoute){
    activatedRoute.params.subscribe();
  }

  login(loginParam: Login, form: NgForm) {
      this.loginService.login(loginParam).then( response => {
        this.authService.logIn();
      })
      .catch(error => {
        alert
        ("User not found!")
      })
  }
  
  goToAccomodations() {
    this.router.navigate(['/accomodations']);
  }
}
