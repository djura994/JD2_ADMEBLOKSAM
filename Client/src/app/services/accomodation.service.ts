import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { Accomodation } from '../models/accomodation.model';
 
import 'rxjs/add/operator/toPromise';

@Injectable()
export class AccomodationService {
    private accomodationUrl = 'http://localhost:54042/api/accommodations';

    constructor(private http: Http) { }

 getAccommondations(): Promise<Accomodation[]> {
    return this.http.get(this.accomodationUrl+"?$expand=owner,place/region/country")
      .toPromise()
      .then(response => {
          return response.json() as Accomodation[]; })
      .catch(this.handleError);
  }

  postAccomodation(accomodation: Accomodation): Promise<Accomodation> {

       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    return this.http
      .post(this.accomodationUrl, JSON.stringify(accomodation), { headers: headers })
      .toPromise()
      .then(res => res.json() as Accomodation)
      .catch(this.handleError);
    
  }

  putAccomodation(accomodation: Accomodation): Promise<Accomodation> {
       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.accomodationUrl}/${accomodation.Id}`;
    return this.http
      .put(url, JSON.stringify(accomodation), { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Accomodation;})
      .catch(this.handleError);
    
  }

  deleteAccomodation(accomodation: Accomodation): Promise<Accomodation> {
    const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.accomodationUrl}/${accomodation.Id}`;
    return this.http
      .delete(url, { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Accomodation;})
      .catch(this.handleError);
    
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}