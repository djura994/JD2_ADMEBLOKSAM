import { Component, OnInit, Input } from '@angular/core';
import { Accomodation } from '../models/accomodation.model';
import { AccomodationService } from '../services/accomodation.service';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Room } from '../models/room.model';
import { Place } from '../models/place.model';
import { AccomodationType } from '../models/accomodationType.model';
import { User } from '../models/user.model';
import { RoomsService } from '../services/room.service';
import { PlaceService } from '../services/place.service';
import { AccomodationTypeService } from '../services/accomodationType.service';
import { UserService } from '../services/userService';
import { Comment } from '../models/comment.model';
import { CommentService } from '../services/comment.service';

@Component({
  selector: 'comment',
  templateUrl: './comment.component.html',
})

export class CommentComponent implements OnInit {

  @Input()  comments: Comment[] = [];
  accomodations: Accomodation[];
  users: User[];
  

  constructor(private router: Router, private accomodationService: AccomodationService, private userService : UserService, private commentService: CommentService ) { }

    error: any

  ngOnInit() {
      this.commentService.getComments().then((comments) => {
          this.comments = comments;
        })
    this.accomodationService.getAccommondations().then((accomodations) => {
          this.accomodations = accomodations;
        })
        this.userService.getUsers().then((users) => {
          this.users = users;
        })
  }
    
    addComment(comment: Comment, form: NgForm) {
    var placeElement = Number.parseInt((<HTMLInputElement>document.getElementById("Accomodation")).value);
    comment.Accomodation = this.accomodations[placeElement - 1];

    this.commentService.postComment(comment).then(comment => {
      comment = comment; 
     alert("Comment sucessfuly added.");
      })
        .catch(error => this.error = error);
  }

}

