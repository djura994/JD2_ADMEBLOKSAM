import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { RoomReservation } from '../models/roomReservation.model'

import 'rxjs/add/operator/toPromise';

@Injectable()
export class UserService {
  private headers = new Headers({'Content-Type': 'application/json'});
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

  getReservations(): Promise<RoomReservation[]> { 
    return this.http.get(this.roomReservationsUrl+"?$expand=Room/accomodation/owner,Room/accomodation/place/region/country")
      .toPromise()
      .then(response => {
          debugger
          return response.json() as RoomReservation[]; })
      .catch(this.handleError);
  }

reserveRoom(room: RoomReservation): Promise<RoomReservation> {
       const headers = new Headers({
      'Content-Type': 'application/json'
    });
    let url = `${this.roomReservationsUrl}`;
    return this.http
      .post(url, JSON.stringify(room), { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as RoomReservation;})
      .catch(this.handleError);
    
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}
