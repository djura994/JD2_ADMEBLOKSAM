namespace BookingApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ModelClasses;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookingApp.Models.BAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookingApp.Models.BAContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (System.Diagnostics.Debugger.IsAttached == false)            {                System.Diagnostics.Debugger.Launch();            }            if (!context.Roles.Any(r => r.Name == "Admin"))            {                var store = new RoleStore<IdentityRole>(context);                var manager = new RoleManager<IdentityRole>(store);                var role = new IdentityRole { Name = "Admin" };                manager.Create(role);            }            if (!context.Roles.Any(r => r.Name == "Manager"))            {                var store = new RoleStore<IdentityRole>(context);                var manager = new RoleManager<IdentityRole>(store);                var role = new IdentityRole { Name = "Manager" };                manager.Create(role);            }            if (!context.Roles.Any(r => r.Name == "AppUser"))            {                var store = new RoleStore<IdentityRole>(context);                var manager = new RoleManager<IdentityRole>(store);                var role = new IdentityRole { Name = "AppUser" };                manager.Create(role);            }            Country c1 = new Country();            c1.Code = 123;            c1.Name = "Srbija";            Region r1 = new Region();            r1.Name = "Balkan";            r1.country = c1;            r1.m_Place = new List<Place>();            Place p1 = new Place();            p1.Name = "Glusci, Krnj'ca brdo";            p1.region = r1;            r1.m_Place.Add(p1);            Accommodation a1 = new Accommodation();            a1.Name = "Kod groblja ..";            a1.Description = "Ladovina Bog da te vidi";            a1.Address = "Crkveno dvoriste";            a1.AverageGrade = 0;            a1.Latitude = 45.242218;            a1.Longitude = 19.855324;            a1.ImageURL = "http://static.panoramio.com/photos/large/3925576.jpg";            a1.Approved = true;            a1.m_Comment = new List<Comment>(1);            a1.place = p1;            p1.m_Accommodation = new List<Accommodation>(1) { a1 };            Room room1 = new Room();            room1.RoomNumber = 1;            room1.BedCount = 1;            room1.Description = "Rezervacija neophodna!";            room1.PricePerNight = 11;            room1.accomodation = a1;            a1.m_Room = new List<Room>(1) { room1 };            RoomReservation rr = new RoomReservation();            rr.StartDate = DateTime.Now;            rr.EndDate = DateTime.Now.AddDays(1);            rr.Timestamp = DateTime.Now;            AppUser user = new AppUser();            user.Username = "testUser";            user.Password = "test123";            user.Email = "testUser@mailinator.com";            user.m_Accommodation = new List<Accommodation>(1) { a1 };            user.m_RoomReservations = new List<RoomReservation>(1) { rr };            Comment cmm = new Comment();            cmm.Grade = 1;            cmm.Text = "no comment";            cmm.user = user;            cmm.accomodation = a1;            AccommodationType type = new AccommodationType();            type.Name = "HAD";            type.m_Accommodation = new List<Accommodation>(1) { a1 };            try
            {                context.roomReservations.Add(rr);                context.accommodations.Add(a1);                context.accommodationTypes.Add(type);                context.rooms.Add(room1);                context.regions.Add(r1);                context.places.Add(p1);                context.AppUsers.Add(user);                context.comments.Add(cmm);                context.SaveChanges();                var userStore = new UserStore<BAIdentityUser>(context);                var userManager = new UserManager<BAIdentityUser>(userStore);                if (!context.Users.Any(u => u.UserName == "testUser"))                {                    var _appUser = context.AppUsers.FirstOrDefault(a => a.Email == "testUser@mailinator.com");                    var user3 = new BAIdentityUser() { Id = "testUser", UserName = "testUser", Email = "testUser@mailinator.com", PasswordHash = BAIdentityUser.HashPassword("test123"), appUserId = _appUser.Id };                    userManager.Create(user3);                    userManager.AddToRole(user3.Id, "AppUser");                }            }            catch (Exception e)            {            }

        }
    }
}
