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
using Tp3WebApiMarcio;
using Tp3WebApiMarcio.Models;

namespace WebApi.Controllers
{
    [Authorize]
    public class AmigosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Amigos
        public IQueryable<Amigo> GetAmigos()
        {
            return db.Amigos;
        }

        // GET: api/Amigos/5
        [ResponseType(typeof(Amigo))]
        public IHttpActionResult GetAmigo(int id)
        {
            Amigo amigo = db.Amigos.Find(id);
            if (amigo == null)
            {
                return NotFound();
            }

            return Ok(amigo);
        }

        // PUT: api/Amigos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAmigo(int id, Amigo amigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amigo.Id)
            {
                return BadRequest();
            }

            db.Entry(amigo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmigoExists(id))
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

        // POST: api/Amigos
        [AllowAnonymous]
        [ResponseType(typeof(Amigo))]
        public IHttpActionResult PostAmigo(Amigo amigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Amigos.Add(amigo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = amigo.Id }, amigo);
        }

        // DELETE: api/Amigos/5
        [ResponseType(typeof(Amigo))]
        public IHttpActionResult DeleteAmigo(int id)
        {
            Amigo amigo = db.Amigos.Find(id);
            if (amigo == null)
            {
                return NotFound();
            }

            db.Amigos.Remove(amigo);
            db.SaveChanges();

            return Ok(amigo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AmigoExists(int id)
        {
            return db.Amigos.Count(e => e.Id == id) > 0;
        }
    }
}