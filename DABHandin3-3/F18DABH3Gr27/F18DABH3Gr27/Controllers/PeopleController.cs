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
using System.Web.Http.Results;
using F18DABH3Gr27.Models;
using Microsoft.Azure.Documents;

//// Followed tutorial to create Repository:  https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-dotnet-application

namespace F18DABH3Gr27.Controllers
{
    public class PeopleController : ApiController
    {
        //private F18DABH3Gr27Context db = new F18DABH3Gr27Context();


        //// GET: People
        //public ActionResult Index()
        //{
        //    return View();
        ////}
        //GET: one person from datafrom using the person.Id
        [ResponseType(typeof(Person))]
        public async Task<Person> GetPerson(string id)
        {
            return await Repository.Repository<Person>.GetPersonAsync(id);

        }

        //GET: all people from database
        public async Task<IEnumerable<Person>> GetPeople()
        {
            var person = await Repository.Repository<Person>.GetPersonsAsync(d => true);
            return person;
        }



        // PUT: api/People/5 UPDATE
        [ResponseType(typeof(void))]
        public async Task<Document> PutPerson(string id, Person person)
        {
            return await Repository.Repository<Person>.UpdatePersonAsync(id, person);
        }

        //POST
        [ResponseType(typeof(Person))]
        public async Task<Document> PostPerson(Person person)
        {
            return await Repository.Repository<Person>.CreatePersonAsync(person);
        }

        //DELETE
        [ResponseType(typeof(Person))]
        public async Task DeletePerson(string id)
        {
            await Repository.Repository<Person>.DeletePersonAsync(id);
        }
    }
}
//    public async Task<IEnumerable<Person>> GetPeople()
//    {
//        var person = await DocumentDBRepository<Person>.GetItemsAsync(d => d.CreatedPeron);
//        return person;
//    }

//    [ActionName("Index")]
//    public async Task<ActionResult> IndexAsync()
//    {
//        var person = await DocumentDBRepository<Person>.GetItemsAsync(d => !d.CreatedPeron);
//        return View(person);
//    }

//    [HttpPost]
//    [ActionName("Edit")]
//    [ValidateAntiForgeryToken]
//    public async Task<ActionResult> EditAsync([Bind(Include = "Id,Name,Description,Completed")] Person person)
//    {
//        if (ModelState.IsValid)
//        {
//            await DocumentDBRepository<Person>.UpdateItemAsync(person.Id, person);
//                //.UpdateItemAsync(item.Id, item);
//            return RedirectToAction("Index");
//        }

//        return View(person);
//    }

//    [ActionName("Edit")]
//    public async Task<ActionResult> EditAsync(string id)
//    {
//        if (id == null)
//        {
//            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        }

//        Person person = await DocumentDBRepository<Person>.GetItemAsync(id);
//        if (person == null)
//        {
//            return HttpNotFound();
//        }

//        return View(person);
//    }
//}




//// GET: api/People/5
//[ResponseType(typeof(Person))]
//public async Task<IHttpActionResult> GetPerson(string id)
//{
//    Person person = await db.People.FindAsync(id);
//    if (person == null)
//    {
//        return NotFound();
//    }

//    return Ok(person);
//}

//// PUT: api/People/5
//[ResponseType(typeof(void))]
//public async Task<IHttpActionResult> PutPerson(string id, Person person)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }

//    if (id != person.Id)
//    {
//        return BadRequest();
//    }

//    db.Entry(person).State = EntityState.Modified;

//    try
//    {
//        await db.SaveChangesAsync();
//    }
//    catch (DbUpdateConcurrencyException)
//    {
//        if (!PersonExists(id))
//        {
//            return NotFound();
//        }
//        else
//        {
//            throw;
//        }
//    }

//    return StatusCode(HttpStatusCode.NoContent);
//}

//// POST: api/People
//[ResponseType(typeof(Person))]
//public async Task<IHttpActionResult> PostPerson(Person person)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }

//    db.People.Add(person);

//    try
//    {
//        await db.SaveChangesAsync();
//    }
//    catch (DbUpdateException)
//    {
//        if (PersonExists(person.Id))
//        {
//            return Conflict();
//        }
//        else
//        {
//            throw;
//        }
//    }

//    return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
//}

//// DELETE: api/People/5
//[ResponseType(typeof(Person))]
//public async Task<IHttpActionResult> DeletePerson(string id)
//{
//    Person person = await db.People.FindAsync(id);
//    if (person == null)
//    {
//        return NotFound();
//    }

//    db.People.Remove(person);
//    await db.SaveChangesAsync();

//    return Ok(person);
//}

//protected override void Dispose(bool disposing)
//{
//    if (disposing)
//    {
//        db.Dispose();
//    }
//    base.Dispose(disposing);
//}

//private bool PersonExists(string id)
//{
//    return db.People.Count(e => e.Id == id) > 0;
//}