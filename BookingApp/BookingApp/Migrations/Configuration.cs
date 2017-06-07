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
            //Accommodation accomm = new Accommodation();
            //accomm.Name = "Test accommodation";

            //Room room = new Room();
            //room.BedCount = 10;

            //Comment com = new Comment();
            //com.Grade = 4;

            AppUser auser = new AppUser();
            auser.Email = "rosicnemanja94@gmail.com";
            auser.FullName = "Nemanja Rosic";
            //  auser.m_Accommodation.Add(accomm);

            //context.accommodations.Add(accomm);
            context.AppUsers.Add(auser);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Manager" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }

            context.AppUsers.AddOrUpdate(
                  p => p.FullName,
                  new AppUser() { FullName = "Admin Adminovic" }
            );
            context.AppUsers.AddOrUpdate(
                p => p.FullName,
                new AppUser() { FullName = "AppUser AppUserovic" }
            );
            context.SaveChanges();

            var userStore = new UserStore<BAIdentityUser>(context);
            var userManager = new UserManager<BAIdentityUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user = new BAIdentityUser() { Id = "admin", UserName = "admin", Email = "admin@yahoo.com", PasswordHash = BAIdentityUser.HashPassword("admin") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
