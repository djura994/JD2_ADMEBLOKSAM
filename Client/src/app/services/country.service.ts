import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { Region } from '../models/region.model';
import {Country } from '../models/country.model';
 
import 'rxjs/add/operator/toPromise';

@Injectable()
export class CountryService {
    private countriesUrl = 'http://localhost:54042/api/countries';

    constructor(private http: Http) { }

 getCountries(): Promise<Country[]> {
    return this.http.get(this.countriesUrl)
      .toPromise()
      .then(response => {
          return response.json() as Country[]; })
      .catch(this.handleError);
  }

  postCountry(country: Country): Promise<Country> {

       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    return this.http
      .post(this.countriesUrl, JSON.stringify(country), { headers: headers })
      .toPromise()
      .then(res => res.json() as Country)
      .catch(this.handleError);
    
  }

  putCountry(country: Country): Promise<Country> {
       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.countriesUrl}/${country.Id}`;
    return this.http
      .put(url, JSON.stringify(country), { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Country;})
      .catch(this.handleError);
    
  }

  deleteCountry(country: Country): Promise<Country> {
    const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.countriesUrl}/${country.Id}`;
    return this.http
      .delete(url, { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Country;})
      .catch(this.handleError);
    
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}