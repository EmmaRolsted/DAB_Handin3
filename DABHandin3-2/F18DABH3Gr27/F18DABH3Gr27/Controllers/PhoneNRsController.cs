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
using F18DABH3Gr27.Models;

namespace F18DABH3Gr27.Controllers
{
    public class PhoneNRsController : ApiController
    {
        private F18DABH3Gr27Context db = new F18DABH3Gr27Context();

        // GET: api/PhoneNRs
        public IQueryable<PhoneNR> GetPhoneNRs()
        {
            return db.PhoneNRs;
        }

        // GET: api/PhoneNRs/5
        [ResponseType(typeof(PhoneNR))]
        public async Task<IHttpActionResult> GetPhoneNR(int id)
        {
            PhoneNR phoneNR = await db.PhoneNRs.FindAsync(id);
            if (phoneNR == null)
            {
                return NotFound();
            }

            return Ok(phoneNR);
        }

        // PUT: api/PhoneNRs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhoneNR(int id, PhoneNR phoneNR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneNR.Id)
            {
                return BadRequest();
            }

            db.Entry(phoneNR).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneNRExists(id))
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

        // POST: api/PhoneNRs
        [ResponseType(typeof(PhoneNR))]
        public async Task<IHttpActionResult> PostPhoneNR(PhoneNR phoneNR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhoneNRs.Add(phoneNR);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = phoneNR.Id }, phoneNR);
        }

        // DELETE: api/PhoneNRs/5
        [ResponseType(typeof(PhoneNR))]
        public async Task<IHttpActionResult> DeletePhoneNR(int id)
        {
            PhoneNR phoneNR = await db.PhoneNRs.FindAsync(id);
            if (phoneNR == null)
            {
                return NotFound();
            }

            db.PhoneNRs.Remove(phoneNR);
            await db.SaveChangesAsync();

            return Ok(phoneNR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneNRExists(int id)
        {
            return db.PhoneNRs.Count(e => e.Id == id) > 0;
        }
    }
}