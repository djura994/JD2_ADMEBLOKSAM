
import { User } from '../models/user.model';
import { Accomodation } from '../models/accomodation.model';

export class Comment {
  constructor(
    public Id: number,
    public Grade: number,
    public Text: string,
    public User: User,
    public Accomodation: Accomodation
   ) {
  }
}
