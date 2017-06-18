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
    public class RoomReservationsController : ApiController
    {
        private BAContext db = new BAContext();

        // GET: api/RoomReservations
        public IQueryable<RoomReservation> GetRoomReservations()
        {
            return db.roomReservations;
        }

        // GET: api/RoomReservations/5
        [ResponseType(typeof(RoomReservation))]
        public IHttpActionResult GetRoomReservations(int id)
        {
            RoomReservation roomReservations = db.roomReservations.Find(id);
            if (roomReservations == null)
            {
                return NotFound();
            }

            return Ok(roomReservations);
        }

        // PUT: api/RoomReservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoomReservations(int id, RoomReservation roomReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomReservation.Id)
            {
                return BadRequest();
            }

            db.Entry(roomReservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomReservationsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = roomReservation.Id }, roomReservation);
        }

        // POST: api/RoomReservations
        [ResponseType(typeof(RoomReservation))]
        public IHttpActionResult PostRoomReservations(RoomReservation roomReservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.rooms.Attach(roomReservations.room);
            db.accommodations.Attach(roomReservations.room.accomodation);
            db.AppUsers.Attach(roomReservations.user);

            db.roomReservations.Add(roomReservations);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roomReservations.Id }, roomReservations);
        }

        // DELETE: api/RoomReservations/5
        [ResponseType(typeof(RoomReservation))]
        public IHttpActionResult DeleteRoomReservations(int id)
        {
            RoomReservation roomReservations = db.roomReservations.Find(id);
            if (roomReservations == null)
            {
                return NotFound();
            }
           

            db.roomReservations.Remove(roomReservations);
            db.SaveChanges();

            return Ok(roomReservations);
        }

        private bool RoomReservationsExists(int id)
        {
            return db.roomReservations.Count(e => e.Id == id) > 0;
        }
    }
}
