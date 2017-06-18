import { Component, OnInit, Input } from '@angular/core';
import { Accomodation } from '../models/accomodation.model';
import { AccomodationService } from '../services/accomodation.service';
import { Router } from '@angular/router';
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
  selector: 'accomodations',
  templateUrl: './accomodations.component.html',
  styleUrls: ['./accomodations.component.css']
})

export class AccomodationComponent implements OnInit {

  @Input() accomodations: Accomodation[];
  @Input()  rooms: Room[] = [];
  @Input()  places: Place[] = [];
  @Input()  types: AccomodationType[] = [];
  @Input()  users: User[] = [];

  constructor(private router: Router, private accomodationService: AccomodationService, private roomService : RoomsService,
  private placeService : PlaceService , private accomodationTypeService : AccomodationTypeService, private userService : UserService
  
  ) { }

    
    error: any

  ngOnInit() {
      this.accomodationService.getAccommondations().then((accomodations) => {
          this.accomodations = accomodations;
        })
      
    this.roomService.getRooms().then((rooms)=> {

        this.rooms=rooms;
      })


      this.placeService.getPlaces().then((places)=> {

        this.places=places;
      })

      this.accomodationTypeService.getTypes().then((types)=> {

        this.types=types;
      })

      this.userService.getUsers().then((users)=> {

        this.users=users;
    
      })
  }
    
    AddAccomodation(acc: Accomodation, form: NgForm) {
    var placeElement = Number.parseInt((<HTMLInputElement>document.getElementById("PlaceId")).value);
    acc.Place = this.places[placeElement - 1];
    console.log(acc.Place.Region);
    
    var accomodationTypeNum = Number.parseInt((<HTMLInputElement>document.getElementById("AccommodationTypeId")).value);
    acc.Accomodation_Type = this.types[accomodationTypeNum - 1];
   
    acc.Owner = this.users[0];

    this.accomodationService.postAccomodation(acc).then(accomondation => {
      acc = accomondation; 
     alert("Accomodation sucessfuly added.");
      })
        .catch(error => this.error = error);
  }

  editAccomodation( acc: Accomodation, form: NgForm ) {
     var placeElement = Number.parseInt((<HTMLInputElement>document.getElementById("PlaceId")).value);   
     acc.Place = this.places[placeElement - 1];
     console.log(acc.Place.Region);
    
     var accomodationTypeNum = Number.parseInt((<HTMLInputElement>document.getElementById("AccommodationTypeId")).value);
     acc.Accomodation_Type = this.types[accomodationTypeNum - 1];
   
     acc.Owner = this.users[0];

     this.accomodationService.putAccomodation(acc).then(accomondation => {
       acc = accomondation; 
      alert("Accomodation sucessfuly changed.");
       })
        .catch(error => this.error = error);
 }

 deleteAccomodation() {
     console.log("aaaa");
     
    var id =  Number.parseInt((<HTMLInputElement>document.getElementById("accomodationId")).value);
    this.accomodationService.deleteAccomodation(id).then
    (accomodation => {       
     alert("Accomodation sucessfuly deleted.");
       })
        .catch(error => this.error = error);
 }
}

