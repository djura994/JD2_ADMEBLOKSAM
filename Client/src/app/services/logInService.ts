import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { Login } from '../models/logIn.model';
import { User } from '../models/user.model';
import { UserService  } from '../services/userService';
 
import 'rxjs/add/operator/toPromise';

@Injectable()
export class LogInService {

  private header = new Headers({'Content-Type': 'application/json'});

  private loginUrl = 'http://localhost:54042/oauth/token';
  private usersUrl = 'http://localhost:54042/api/Appusers/'

  constructor(private http: Http) { }

  login(login : Login): Promise<User> {
      var body = "username="+login.username+"&password="+login.password+"&grant_type=password";
      var options = new RequestOptions();
      let hd = new Headers();
      hd.append("Content-Type", "application/x-www-form-urlencoded");
      options.headers = hd;

      return this.http.post(this.loginUrl,
          body, 
          options)
          .toPromise()
          .then(data => {
            debugger
             localStorage.setItem("token", data.json().access_token);
             localStorage.setItem("username", login.username);
             return this.getUser(login.username , data.json().access_token)    
          })
          .catch(this.handleError);
  }
  getUser(username : string, token: String): Promise<User> {
    return this.http.get(this.usersUrl+"?$filter=id eq "+username)
      .toPromise()
      .then(response => {
        debugger
          localStorage.setItem("email", response.json()[0].Email);
          return response.json() as User;})
      .catch(this.handleError);
}

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}