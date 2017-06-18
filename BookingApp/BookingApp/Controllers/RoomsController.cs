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
    public class RoomsController : ApiController
    {
        private BAContext db = new BAContext();

        // GET: api/Rooms
        public IQueryable<Room> GetRooms()
        {
            return db.rooms;
        }

        // GET: api/Rooms/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult GetRoom(int id)
        {
            Room room = db.rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // PUT: api/Rooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoom(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room.Id)
            {
                return BadRequest();
            }

            db.Entry(room).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = room.Id }, room);
        }

        // POST: api/Rooms
        [ResponseType(typeof(Room))]
        public IHttpActionResult PostRoom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.accommodations.Attach(room.accomodation);

            db.rooms.Add(room);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [ResponseType(typeof(Room))]
        public IHttpActionResult DeleteRoom(int id)
        {
            Room room = db.rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            db.rooms.Remove(room);
            db.SaveChanges();

            return Ok(room);
        }

        private bool RoomExists(int id)
        {
            return db.rooms.Count(e => e.Id == id) > 0;
        }
    }
}
