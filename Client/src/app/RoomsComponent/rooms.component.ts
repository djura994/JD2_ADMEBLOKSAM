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

@Component({
  selector: 'rooms',
  templateUrl: './rooms.component.html',
})

export class RoomsComponent implements OnInit {

  @Input()  rooms: Room[] = [];
  accomodations: Accomodation[];
  room: Room;

  constructor(private router: Router, private accomodationService: AccomodationService, private roomService : RoomsService
  
  ) { }

    error: any

  ngOnInit() {
      this.accomodationService.getAccommondations().then((accomodations) => {
          this.accomodations = accomodations;
        })
      
    this.roomService.getRooms().then((rooms)=> {

        this.rooms=rooms;
      })
  }
    
    addRoom(room: Room, form: NgForm) {
    var placeElement = Number.parseInt((<HTMLInputElement>document.getElementById("Accomodation")).value);
    room.Accomodation = this.accomodations[placeElement - 1];

    this.roomService.postRoom(room).then(room => {
      room = room; 
     alert("Room sucessfuly added.");
      })
        .catch(error => this.error = error);
  }

  editRoom( room: Room, form: NgForm ) {
     var placeElement = Number.parseInt((<HTMLInputElement>document.getElementById("Accomodation")).value);
     room.Accomodation = this.accomodations[placeElement - 1];

     this.roomService.putRoom(room).then(room => {
       room = room; 
      alert("Room sucessfuly changed.");
       })
        .catch(error => this.error = error);
 }

 deleteRoom() {
     
    var id =  Number.parseInt((<HTMLInputElement>document.getElementById("roomId")).value);
    this.roomService.deleteRoom(id).then
    (accomodation => {       
     alert("Room sucessfuly deleted.");
       })
        .catch(error => this.error = error);
 }

 goToComments() {
     this.router.navigate(['./comment']);
 }

}

