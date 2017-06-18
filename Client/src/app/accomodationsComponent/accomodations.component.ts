import { Component, OnInit, Input } from '@angular/core';
import { Accomodation } from '../models/accomodation.model';

@Component({
  selector: 'accomodation',
  templateUrl: './accomodations.component.html',
  styleUrls: ['./accomodations.component.css']
})

export class AccomodationComponent implements OnInit {

  @Input() accomodation: Accomodation


  constructor() { }

  ngOnInit() {
  }

}