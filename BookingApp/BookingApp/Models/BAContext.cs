using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ModelClasses;

namespace BookingApp.Models
{
    public class BAContext: IdentityDbContext<BAIdentityUser>
    {   
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Accommodation> accommodations { get; set; }
        public virtual DbSet<AccommodationType> accommodationTypes { get; set; }
        public virtual DbSet<Comment> comments { get; set; }
        public virtual DbSet<Country> countries { get; set; }
        public virtual DbSet<Place> places { get; set; }
        public virtual DbSet<Region> regions { get; set; }
        public virtual DbSet<Room> rooms { get; set; }
        public virtual DbSet<RoomReservation> roomReservations { get; set; }
        public object Comments { get; internal set; }

        public BAContext() : base("name=BADB")
        {            
        }

        

        public static BAContext Create()
        {
            return new BAContext();
        }
    }
}