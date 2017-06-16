
import { Room } from '../models/room.model';
import { Comment } from '../models/comment.model';
import { Place } from '../models/place.model';
import { User } from '../models/user.model';
import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

export class Accomodation {

    public Id: number;
    public Name: string;
    public Description: string;
    public Address: string;
    public AverageGrade: string;
    public Latitude: number;
    public Longitude: number;
    public ImageUrl: string;
    public Approved: boolean = false;
    public Owner: User;
    public Place_Id: number;
    public Accomodation_Type: number;
    public m_Comment: Array<Comment>;
    public m_Room: Array<Room>;
    public Place: Place

    constructor( private router: Router) {

    }


}
