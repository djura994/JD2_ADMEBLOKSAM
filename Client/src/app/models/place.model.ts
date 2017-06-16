
import { Region } from '../models/region.model';
import { Accomodation } from '../models/accomodation.model';


export class Place {
  constructor(
    public Id: number,
    public Name: string,

    public Region: Region,
    public m_Accomodations: Array<Accomodation>
   ) {
  }
}
