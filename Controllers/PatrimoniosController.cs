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
using DesafioApi.Models;

namespace DesafioApi.Controllers
{
    public class PatrimoniosController : ApiController
    {
        private DesafioApiContext db = new DesafioApiContext();

        // GET: api/Patrimonios
        public IQueryable<Patrimonio> GetPatrimonio()
        {
            return db.Patrimonio;
        }

        // GET: api/Patrimonios/5
        [ResponseType(typeof(Patrimonio))]
        public IHttpActionResult GetPatrimonio(int id)
        {
            Patrimonio patrimonio = db.Patrimonio.Find(id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            return Ok(patrimonio);
        }

        // PUT: api/Patrimonios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatrimonio(int id, Patrimonio patrimonio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patrimonio.PatrimonioId)
            {
                return BadRequest();
            }

            db.Entry(patrimonio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatrimonioExists(id))
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

        // POST: api/Patrimonios
        [ResponseType(typeof(Patrimonio))]
        public IHttpActionResult PostPatrimonio(Patrimonio patrimonio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patrimonio.Add(patrimonio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patrimonio.PatrimonioId }, patrimonio);
        }

        // DELETE: api/Patrimonios/5
        [ResponseType(typeof(Patrimonio))]
        public IHttpActionResult DeletePatrimonio(int id)
        {
            Patrimonio patrimonio = db.Patrimonio.Find(id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            db.Patrimonio.Remove(patrimonio);
            db.SaveChanges();

            return Ok(patrimonio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatrimonioExists(int id)
        {
            return db.Patrimonio.Count(e => e.PatrimonioId == id) > 0;
        }
    }
}