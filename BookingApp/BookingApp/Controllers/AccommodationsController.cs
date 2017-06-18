using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookingApp.Models;
using ModelClasses;

namespace BookingApp.Controllers
{
    public class AccommodationsController : ApiController
    {
        private BAContext db = new BAContext();

        // GET: api/Accommodations
        [Authorize]
        public IQueryable<Accommodation> GetAccomondations()
        {
            return db.accommodations;
        }

        // GET: api/Accommodations/5
        [ResponseType(typeof(Accommodation))]
        public IHttpActionResult GetAccommodation(int id)
        {
            Accommodation accommodation = db.accommodations.Find(id);
            if (accommodation == null)
            {
                return NotFound();
            }

            return Ok(accommodation);
        }

        // PUT: api/Accommodations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccommodation(int id, Accommodation accommodation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accommodation.Id)
            {
                return BadRequest();
            }

            db.Entry(accommodation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommodationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accommodation.Id }, accommodation);
        }

        // POST: api/Accommodations
        [ResponseType(typeof(Accommodation))]
        public IHttpActionResult PostAccommodation(Accommodation accommodation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppUsers.Attach(accommodation.owner);
            db.places.Attach(accommodation.place);


            db.accommodations.Add(accommodation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accommodation.Id }, accommodation);
        }

        // DELETE: api/Accommodations/5
        [ResponseType(typeof(Accommodation))]
        public IHttpActionResult DeleteAccommodation(int id)
        {
            Accommodation accommodation = db.accommodations.Find(id);
            if (accommodation == null)
            {
                return NotFound();
            }

            db.accommodations.Remove(accommodation);
            db.SaveChanges();

            return Ok(accommodation);
        }

        private bool AccommodationExists(int id)
        {
            return db.accommodations.Count(e => e.Id == id) > 0;
        }
    }
}