import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { Room } from '../models/room.model'

import 'rxjs/add/operator/toPromise';

@Injectable()
export class UserService {
  private headers = new Headers({'Content-Type': 'application/json'});
 
  private roomsUrl = 'http://localhost:54042/api/rooms/'
  private roomReservationsUrl = 'http://localhost:54042/api/roomReservations/'


  constructor(private http: Http) { }

  wasRoomReserved(roomId :number, username :string) : Promise<boolean> {
    return this.http.get(this.roomReservationsUrl+"?$filter=Room_id eq "+roomId+"$User_id eq "+username)
          .toPromise()
          .then(response => {
              if (response.json().size() === 0)
                return false;
              
              return true;
            })
          .catch(this.handleError);
          
  }
   getRooms(): Promise<Room[]> { 
    return this.http.get(this.roomsUrl+"?$expand=accomodation/owner,accomodation/place/region/country")
      .toPromise()
      .then(response => {
          return response.json() as Room[]; })
      .catch(this.handleError);
  }
  postRoom(room: Room): Promise<Room> {

       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    return this.http
      .post(this.roomsUrl, JSON.stringify(room), { headers: headers })
      .toPromise()
      .then(res => res.json() as Room)
      .catch(this.handleError);
    
  }
  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}