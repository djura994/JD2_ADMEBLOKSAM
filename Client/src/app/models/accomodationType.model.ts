
import { Accommondation } from '../models/accomodation.model';


export class AccomodationType {
  constructor(
    public Id: number,
    public Name: string,
    public m_Accomodation: Array<Accommondation>
   ) {
  }
}
