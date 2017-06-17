import { Room } from '../models/room.model';
import { User } from '../models/user.model';

export class RoomReservation {
  constructor(
    public id: number,
    public endDate: Date,
    public startDate: Date,
    public timeStamp: Date,
    public room: Room,
    public user: User
   ) {
  }
}
