import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { Place } from '../models/place.model'
import 'rxjs/add/operator/toPromise';

@Injectable()
export class PlaceService {
  private header = new Headers({'Content-Type': 'application/json'});
  private placesUrl = 'http://localhost:54042/api/places'
 
 

 constructor(private http: Http) { }

 getPlaces(): Promise<Place[]> { 
    return this.http.get(this.placesUrl+"?$expand=region/country")
      .toPromise()
      .then(response => {
          return response.json() as Place[]; })
      .catch(this.handleError);
  }

postPlace(place: Place): Promise<Place> {

       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    return this.http
      .post(this.placesUrl, JSON.stringify(place), { headers: headers })
      .toPromise()
      .then(res => res.json() as Place)
      .catch(this.handleError);
    
  }

  putPlace(place: Place): Promise<Place> {
       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.placesUrl}/${place.Id}`;
    return this.http
      .put(url, JSON.stringify(place), { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Place;})
      .catch(this.handleError);
    
  }

  deletePlace(place: Place): Promise<Place> {
    const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.placesUrl}/${place.Id}`;
    return this.http
      .delete(url, { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Place;})
      .catch(this.handleError);
    
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}