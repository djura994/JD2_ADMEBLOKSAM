import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { Region } from '../models/region.model';
 
import 'rxjs/add/operator/toPromise';

@Injectable()
export class RegionService {
    private regionsUrl = 'http://localhost:54042/api/regions';

    constructor(private http: Http) { }

 getRegions(): Promise<Region[]> {
    return this.http.get(this.regionsUrl)
      .toPromise()
      .then(response => {
          return response.json() as Region[]; })
      .catch(this.handleError);
  }

  postRegion(region: Region): Promise<Region> {

       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    return this.http
      .post(this.regionsUrl, JSON.stringify(region), { headers: headers })
      .toPromise()
      .then(res => res.json() as Region)
      .catch(this.handleError);
    
  }

  putRegion(region: Region): Promise<Region> {
       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.regionsUrl}/${region.Id}`;
    return this.http
      .put(url, JSON.stringify(region), { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Region;})
      .catch(this.handleError);
    
  }

  deleteRegion(region: Region): Promise<Region> {
    const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.regionsUrl}/${region.Id}`;
    return this.http
      .delete(url, { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Region;})
      .catch(this.handleError);
    
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}