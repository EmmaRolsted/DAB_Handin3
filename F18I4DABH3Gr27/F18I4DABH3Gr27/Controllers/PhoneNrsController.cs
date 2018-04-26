using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using F18I4DABH3Gr27.Models;

namespace F18I4DABH3Gr27.Controllers
{
    public class PhoneNrsController : ApiController
    {
        private F18I4DABH3Gr27Context db = new F18I4DABH3Gr27Context();

        // GET: api/PhoneNrs
        public IQueryable<PhoneNr> GetPhoneNrs()
        {
            return db.PhoneNrs;
        }

        // GET: api/PhoneNrs/5
        [ResponseType(typeof(PhoneNr))]
        public async Task<IHttpActionResult> GetPhoneNr(int id)
        {
            PhoneNr phoneNr = await db.PhoneNrs.FindAsync(id);
            if (phoneNr == null)
            {
                return NotFound();
            }

            return Ok(phoneNr);
        }

        // PUT: api/PhoneNrs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhoneNr(int id, PhoneNr phoneNr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneNr.PhoneNrId)
            {
                return BadRequest();
            }

            db.Entry(phoneNr).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneNrExists(id))
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

        // POST: api/PhoneNrs
        [ResponseType(typeof(PhoneNr))]
        public async Task<IHttpActionResult> PostPhoneNr(PhoneNr phoneNr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhoneNrs.Add(phoneNr);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = phoneNr.PhoneNrId }, phoneNr);
        }

        // DELETE: api/PhoneNrs/5
        [ResponseType(typeof(PhoneNr))]
        public async Task<IHttpActionResult> DeletePhoneNr(int id)
        {
            PhoneNr phoneNr = await db.PhoneNrs.FindAsync(id);
            if (phoneNr == null)
            {
                return NotFound();
            }

            db.PhoneNrs.Remove(phoneNr);
            await db.SaveChangesAsync();

            return Ok(phoneNr);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneNrExists(int id)
        {
            return db.PhoneNrs.Count(e => e.PhoneNrId == id) > 0;
        }
    }
}