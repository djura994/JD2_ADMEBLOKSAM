
import { Region } from '../models/region.model';

export class Country {
  constructor(
    public Code: number,
    public Id: number,
    public Name: string,
    public m_Region: Array<Region>
   ) {
  }
}
