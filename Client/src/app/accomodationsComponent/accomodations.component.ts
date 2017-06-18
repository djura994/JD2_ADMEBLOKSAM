import { Component, OnInit, Input } from '@angular/core';
import { Accomodation } from '../models/accomodation.model';
import { AccomodationService } from '../services/accomodation.service';
import { Router } from '@angular/router';

@Component({
  selector: 'accomodations',
  templateUrl: './accomodations.component.html',
  styleUrls: ['./accomodations.component.css']
})

export class AccomodationComponent implements OnInit {

  @Input() accomodations: Accomodation[]


  constructor(private router: Router, private accomodationService: AccomodationService) { }

  ngOnInit() {
      this.accomodationService.getAccommondations().then((accomodations) => {
          this.accomodations = accomodations;
      })
  }

}