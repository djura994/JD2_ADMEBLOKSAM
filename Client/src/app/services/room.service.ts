import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { Room } from '../models/room.model'

import 'rxjs/add/operator/toPromise';

@Injectable()
export class RoomsService {
  private headers = new Headers({'Content-Type': 'application/json'});
 
  private roomsUrl = 'http://localhost:54042/api/rooms/'

  constructor(private http: Http) { }

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

  putRoom(room: Room): Promise<Room> {
       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.roomsUrl}/${room.Id}`;
    return this.http
      .put(url, JSON.stringify(room), { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Room;})
      .catch(this.handleError);
    
  }

  deleteRoom(room: Room): Promise<Room> {
    const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.roomsUrl}/${room.Id}`;
    return this.http
      .delete(url, { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Room;})
      .catch(this.handleError);
    
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}