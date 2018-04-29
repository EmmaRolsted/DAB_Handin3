using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using F18DABH3Gr27.Models;
using F18DABH3Gr27.Repository;

namespace F18DABH3Gr27.Controllers
{
    public class PeopleController : ApiController
    {
        //GET: api/people
        public async Task<IEnumerable<Person>> GetPeople()
        {
            var unitOfWork = new UnitOfWork<Person>();
            return await unitOfWork.GetAllPeople();
        }
        
        //GET: api/People/5
        public async Task<Person> GetPerson(int id)
        {
            var unitOfwork = new UnitOfWork<Person>();
            return await unitOfwork.FindPersonFromId(id.ToString());
        }

        //POST: api/people
        public async Task PostPerson([FromBody] Person person)
        {
            var unitOfwork = new UnitOfWork<Person>();
            unitOfwork.Add(person);
            await unitOfwork.CommitUpdate();
        }
        
        //PUT: api/people/5
        public async Task PutPerson(int id, [FromBody] Person person)
        {
            var unitOfwork = new UnitOfWork<Person>();
            unitOfwork.Update(person);
            await unitOfwork.CommitUpdate();
        }

        //DELETE: api/people/5
        public async Task DeletePerson(string id)
        {
            var unitOfwork = new UnitOfWork<Person>();
            unitOfwork.delete(id);
            await unitOfwork.CommitUpdate();
        }
    }
}

