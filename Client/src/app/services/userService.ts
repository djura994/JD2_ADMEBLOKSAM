import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { User } from '../models/user.model';
 
import 'rxjs/add/operator/toPromise';

@Injectable()
export class UserService {
    private usersUrl = 'http://localhost:54042/api/Appusers/'

    constructor(private http: Http) { }

getUser(username : string, token: String): Promise<User> {
    return this.http.get(this.usersUrl+"?$filter=username eq "+username)
      .toPromise()
      .then(response => {
        debugger
          localStorage.setItem("email", response.json()[0].Email);
          return response.json() as User;})
      .catch(this.handleError);
}

 getUsers(): Promise<User[]> { 
    return this.http.get(this.usersUrl)
      .toPromise()
      .then(response => {
          debugger
          return response.json() as User[]; })
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}