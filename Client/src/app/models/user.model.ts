
import { RoomReservation } from '../models/roomReservation.model';
import { Comment } from '../models/comment.model';
import { Accomodation } from '../models/accomodation.model';

export class User {

  constructor(
    public Id: number,
    public Username: string,
    public Email: string,
    public Fullname: string,
    public Password: string
   ) {
  }
}
