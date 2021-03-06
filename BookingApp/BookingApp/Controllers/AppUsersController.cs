﻿using BookingApp.Models;
using ModelClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData.Routing;
using System.Web.Http.OData;
using System.Web.Http.Description;

namespace BookingApp.Controllers
{
        public class AppUsersController : ApiController
        {
            private BAContext db = new BAContext();


                                        // GET: api/AppUsers
            [ResponseType(typeof(AppUser))]
            [EnableQuery]
            public IQueryable<AppUser> GetAppUsers()
            {
                  return db.AppUsers;
            }

            // GET: api/AppUsers/5
            [ResponseType(typeof(AppUser))]
            public IHttpActionResult GetAppUser(string username)
            {
                  var appUsers = db.AppUsers;
                foreach(AppUser au in appUsers)
            {
                if(au.Username == username)
                {
                    return Ok(au);
                }
            }
                
                    return NotFound();
                
            }

            // PUT: api/AppUsers/5
            [ResponseType(typeof(void))]
            public IHttpActionResult PutAppUser(int id, AppUser appUser)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != appUser.Id)
                {
                    return BadRequest();
                }

                db.Entry(appUser).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppUserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return StatusCode(HttpStatusCode.NoContent);
            }

            // POST: api/AppUsers
            [ResponseType(typeof(AppUser))]
            public IHttpActionResult PostAppUser(AppUser appUser)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.AppUsers.Add(appUser);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = appUser.Id }, appUser);
            }

            // DELETE: api/AppUsers/5
            [ResponseType(typeof(AppUser))]
            public IHttpActionResult DeleteAppUser(int id)
            {
                AppUser appUser = db.AppUsers.Find(id);
                if (appUser == null)
                {
                    return NotFound();
                }

                db.AppUsers.Remove(appUser);
                db.SaveChanges();

                return Ok(appUser);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }

            private bool AppUserExists(int id)
            {
                return db.AppUsers.Count(e => e.Id == id) > 0;
            }
        }   
}
