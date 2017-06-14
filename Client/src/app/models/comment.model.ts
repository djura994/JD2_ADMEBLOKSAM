
import { User } from '../models/user.model';
import { Accommondation } from '../models/accomodation.model';



export class Comment {
  constructor(
    public Id: number,
    public Grade: number,
    public Text: string,
    public User: User,
    public Accommondation: Accommondation
   ) {
  }
}
