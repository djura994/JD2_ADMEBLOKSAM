
import { Country } from '../models/country.model';
import { Place } from '../models/place.model';

export class Region {
  constructor(
    public Id: number,
    public Name: string,
    public Country: Country,
    public m_Places: Array<Place>

   ) {
  }
}
