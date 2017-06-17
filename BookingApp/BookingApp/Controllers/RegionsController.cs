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
    public class RegionsController : ApiController
    {
        private BAContext db = new BAContext();

        // GET: api/Regions
        public IQueryable<Region> GetRegions()
        {
            return db.regions;
        }

        // GET: api/Regions/5
        [ResponseType(typeof(Region))]
        public IHttpActionResult GetRegion(int id)
        {
            Region region = db.regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        // PUT: api/Regions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegion(int id, Region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != region.Id)
            {
                return BadRequest();
            }

            db.Entry(region).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = region.Id }, region);
        }

        // POST: api/Regions
        [ResponseType(typeof(Region))]
        public IHttpActionResult PostRegion(Region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.regions.Add(region);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = region.Id }, region);
        }

        // DELETE: api/Regions/5
        [ResponseType(typeof(Region))]
        public IHttpActionResult DeleteRegion(int id)
        {
            Region region = db.regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }
            

            db.regions.Remove(region);
            db.SaveChanges();

            return Ok(region);
        }
        private bool RegionExists(int id)
        {
            return db.regions.Count(e => e.Id == id) > 0;
        }
    }
}