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
    public class AltAddressesController : ApiController
    {
        private F18DABH3Gr27Context db = new F18DABH3Gr27Context();

        // GET: api/AltAddresses
        public IQueryable<AltAddress> GetAltAddresses()
        {
            return db.AltAddresses;
        }

        // GET: api/AltAddresses/5
        [ResponseType(typeof(AltAddress))]
        public async Task<IHttpActionResult> GetAltAddress(int id)
        {
            AltAddress altAddress = await db.AltAddresses.FindAsync(id);
            if (altAddress == null)
            {
                return NotFound();
            }

            return Ok(altAddress);
        }

        // PUT: api/AltAddresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAltAddress(int id, AltAddress altAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != altAddress.Id)
            {
                return BadRequest();
            }

            db.Entry(altAddress).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AltAddressExists(id))
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

        // POST: api/AltAddresses
        [ResponseType(typeof(AltAddress))]
        public async Task<IHttpActionResult> PostAltAddress(AltAddress altAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AltAddresses.Add(altAddress);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = altAddress.Id }, altAddress);
        }

        // DELETE: api/AltAddresses/5
        [ResponseType(typeof(AltAddress))]
        public async Task<IHttpActionResult> DeleteAltAddress(int id)
        {
            AltAddress altAddress = await db.AltAddresses.FindAsync(id);
            if (altAddress == null)
            {
                return NotFound();
            }

            db.AltAddresses.Remove(altAddress);
            await db.SaveChangesAsync();

            return Ok(altAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AltAddressExists(int id)
        {
            return db.AltAddresses.Count(e => e.Id == id) > 0;
        }
    }
}