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
    public class AccommodationTypesController : ApiController
    {
        private BAContext db = new BAContext();

        // GET: api/AccommodationTypes
        public IQueryable<AccommodationType> GetAccomondationTypes()
        {
            return db.accommodationTypes;
        }

        // GET: api/AccommodationTypes/5
        [ResponseType(typeof(AccommodationType))]
        public IHttpActionResult GetAccommodationType(int id)
        {
            AccommodationType accommodationType = db.accommodationTypes.Find(id);
            if (accommodationType == null)
            {
                return NotFound();
            }

            return Ok(accommodationType);
        }

        // PUT: api/AccommodationTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccommodationType(int id, AccommodationType accommodationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accommodationType.Id)
            {
                return BadRequest();
            }

            db.Entry(accommodationType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommodationTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accommodationType.Id }, accommodationType);
        }

        // POST: api/AccommodationTypes
        [ResponseType(typeof(AccommodationType))]
        public IHttpActionResult PostAccommodationType(AccommodationType accommodationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.accommodationTypes.Add(accommodationType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accommodationType.Id }, accommodationType);
        }

        // DELETE: api/AccommodationTypes/5
        [ResponseType(typeof(AccommodationType))]
        public IHttpActionResult DeleteAccommodationType(int id)
        {
            AccommodationType accommodationType = db.accommodationTypes.Find(id);
            if (accommodationType == null)
            {
                return NotFound();
            }

            db.accommodationTypes.Remove(accommodationType);
            db.SaveChanges();

            return Ok(accommodationType);
        }

        

        private bool AccommodationTypeExists(int id)
        {
            return db.accommodationTypes.Count(e => e.Id == id) > 0;
        }
    }
}