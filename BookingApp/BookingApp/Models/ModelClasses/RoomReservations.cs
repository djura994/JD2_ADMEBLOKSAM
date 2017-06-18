using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace ModelClasses
{
	public class RoomReservation {

        public int Id { get; set; }
        private Nullable<DateTime> endDate;
        private Nullable<DateTime> startDate;
        private Nullable<DateTime> timestamp;
       
        public Room room { get; set; }
  
        public AppUser user { get; set; }
        public RoomReservation()
        {

        }

        ~RoomReservation()
        {

        }

        public Nullable<DateTime> EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        public Nullable<DateTime> StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        public Nullable<DateTime> Timestamp
        {
            get
            {
                return timestamp;
            }
            set
            {
                timestamp = value;
            }
        }

    }

}