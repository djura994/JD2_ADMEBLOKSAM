import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';
import { RequestOptions } from '@angular/http';
import { User } from '../models/user.model';
import { Accomodation } from '../models/accomodation.model';
import { Comment } from '../models/comment.model';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class CommentService {
  private headers = new Headers({'Content-Type': 'application/json'});
 
  private commentsUrl = 'http://localhost:54042/api/comments/'

  constructor(private http: Http) { }

   getComments(): Promise<Comment[]> { 
    return this.http.get(this.commentsUrl)
      .toPromise()
      .then(response => {
          return response.json() as Comment[]; })
      .catch(this.handleError);
  }
  postComment(comment: Comment): Promise<Comment> {

       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    return this.http
      .post(this.commentsUrl, JSON.stringify(comment), { headers: headers })
      .toPromise()
      .then(res => res.json() as Comment)
      .catch(this.handleError);
    
  }

  putComment(comment: Comment): Promise<Comment> {
       const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.commentsUrl}/${comment.Id}`;
    return this.http
      .put(url, JSON.stringify(comment), { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Comment;})
      .catch(this.handleError);
    
  }

  deleteComment(comment: Comment): Promise<Comment> {
    const headers = new Headers({
      'Content-Type': 'application/json'
    });

    let url = `${this.commentsUrl}/${comment.Id}`;
    return this.http
      .delete(url, { headers: headers })
      .toPromise()
      .then(res => { debugger 
        return res.json() as Comment;})
      .catch(this.handleError);
    
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}