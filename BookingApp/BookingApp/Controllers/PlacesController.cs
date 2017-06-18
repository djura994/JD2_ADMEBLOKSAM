using BookingApp.Models;
using ModelClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookingApp.Controllers
{
    public class PlacesController : ApiController
    {
        private BAContext db = new BAContext();
        public IQueryable<Place> GetPlaces()
        {
            return db.places;
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetPlace(int id)
        {
            Place place = db.places.Find(id);
            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlace(int id, Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != place.Id)
            {
                return BadRequest();
            }

            db.Entry(place).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = place.Id }, place);
        }

        [ResponseType(typeof(Country))]
        public IHttpActionResult PostPlace(Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.regions.Attach(place.region);
            db.places.Add(place);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = place.Id }, place);
        }

        [ResponseType(typeof(Country))]
        public IHttpActionResult DeletePlace(int id)
        {
            Place place = db.places.Find(id);
            if (place == null)
            {
                return NotFound();
            }
            
            db.places.Remove(place);
            db.SaveChanges();

            return Ok(place);
        }

        private bool PlaceExists(int id)
        {
            return db.places.Count(e => e.Id == id) > 0;
        }

    }
}
