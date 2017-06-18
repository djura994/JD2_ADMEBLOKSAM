namespace BookingApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ModelClasses;
    using Models;
    using System;
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
            //  to avoid creating duplicate seed data.

            Country c1 = new Country();
            c1.Code = 123;
            c1.Name = "Srbija";

            Region r1 = new Region();
            r1.Name = "Balkan";
            r1.country = c1;

            Place p1 = new Place();
            p1.Name = "Glusci, Glusacka crkva";
            p1.region = r1;

            AccommodationType type = new AccommodationType();
            type.Name = "Tipa HAD :D";

            Accommodation a1 = new Accommodation();
            a1.Name = "Crkveno dvoriste";
            a1.Description = "Ladovina Bog da te vidi";
            a1.Address = "Na kraj sela, s leva!";
            a1.AverageGrade = 0;
            a1.accomodationType = type;
            a1.Latitude = 45.242217;
            a1.Longitude = 19.855329;
            a1.ImageURL = "https://upload.wikimedia.org/wikipedia/commons/0/03/Glu%C5%A1ci_003.jpg";
            a1.Approved = false;

            a1.place = p1;


            Room room1 = new Room();
            room1.RoomNumber = 1;
            room1.BedCount = 2;
            room1.Description = "Kapelica";
            room1.PricePerNight = 30;
            room1.accomodation = a1;


            RoomReservation rr = new RoomReservation();
            rr.StartDate = DateTime.Now;
            rr.EndDate = DateTime.Now.AddDays(1);
            rr.Timestamp = DateTime.Now;
            rr.room = room1;

            AppUser user = new AppUser();
            user.Username = "testUser";
            user.Password = "test123";
            user.Email = "nagibnizbrdica@mailinator.com";

            rr.user = user;

            a1.owner = user;

            Comment cmm = new Comment();
            cmm.Grade = 1;
            cmm.Text = "Lepsa nego u Uzvecu! xD";
            cmm.user = user;
            cmm.accomodation = a1;

            try
            {
                context.roomReservations.Add(rr);
                context.accommodations.Add(a1);
                context.accommodationTypes.Add(type);
                context.rooms.Add(room1);
                context.regions.Add(r1);
                context.places.Add(p1);
                context.AppUsers.Add(user);
                context.comments.Add(cmm);
                context.SaveChanges();

                var userStore = new UserStore<BAIdentityUser>(context);
                var userManager = new UserManager<BAIdentityUser>(userStore);

                if (!context.Users.Any(u => u.UserName == "testUser"))
                {
                    var _appUser = context.AppUsers.FirstOrDefault(a => a.Email == "nagibnizbrdica@mailinator.com");
                    var testUser = new BAIdentityUser() { Id = "user", UserName = "testUser", Email = "nagibnizbrdica@mailinator.com", PasswordHash = BAIdentityUser.HashPassword("test123"), appUserId = _appUser.Id };
                    userManager.Create(testUser);
                    userManager.AddToRole(testUser.Id, "AppUser");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
