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

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}