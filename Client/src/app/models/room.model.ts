
import { RoomReservation } from '../models/roomReservation.model';
import { Accommondation } from '../models/accomodation.model';


export class Room {
  constructor(

    public Id: number,
    public RoomNumber: number,
    public Description: string,
    public BedCount: number,
    public PricePerNight:number,
    public Accomodation: Accommondation,
    public m_RoomReservations: Array<RoomReservation>
    
   ) {
  }
}
