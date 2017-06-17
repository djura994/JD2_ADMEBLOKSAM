import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { AccomodationType } from '../models/accomodationtype.model'

import 'rxjs/add/operator/toPromise';

@Injectable()
export class AccomodationTypeService {
  private headers = new Headers({'Content-Type': 'application/json'});
  
  private typesUrl = 'http://localhost:54042/api/AccommodationTypes/'
  

  constructor(private http: Http) { }

getTypes(): Promise<AccomodationType[]> { 
    return this.http.get(this.typesUrl)
      .toPromise()
      .then(response => {
          return response.json() as AccomodationType[]; })
      .catch(this.handleError);
  }

  postAccomodationType(accomodationType: AccomodationType): Promise<AccomodationType> {

       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    return this.http
      .post(this.typesUrl, JSON.stringify(accomodationType), { headers: headers })
      .toPromise()
      .then(res => res.json() as AccomodationType)
      .catch(this.handleError);
    
  }

  putAccomodationType(accomodationType: AccomodationType): Promise<AccomodationType> {
       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.typesUrl}/${accomodationType.Id}`;
    return this.http
      .put(url, JSON.stringify(accomodationType), { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as AccomodationType;})
      .catch(this.handleError);
    
  }

   deleteAccomodationType(accomodationType: AccomodationType): Promise<AccomodationType> {
    const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.typesUrl}/${accomodationType.Id}`;
    return this.http
      .delete(url, { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as AccomodationType;})
      .catch(this.handleError);
    
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}