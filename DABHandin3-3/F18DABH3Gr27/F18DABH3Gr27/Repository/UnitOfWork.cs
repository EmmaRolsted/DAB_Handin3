using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using F18DABH3Gr27.Models;

namespace F18DABH3Gr27.Repository
{
    public class UnitOfWork<T> where T : Person
    {
        private readonly List<T> _updateList = new List<T>();
        private readonly List<T> _newList = new List<T>();
        private readonly List<int> _deleteList= new List<int>();

        public async Task InitializeDataBase()
        {
            await Repository<T>.CreateDB();
        }

        public void Add(T item)
        {
            _newList.Add(item);
        }

        public void Update(T item)
        {
            _updateList.Add(item);
        }

        public void delete(string id)
        {
            _deleteList.Add(Convert.ToInt32(id));
        }

        public async Task CommitUpdate()
        {
            foreach (T item in _updateList)
            {
                await Repository<T>.UpdateDocument(item.Id, item);
            }

            foreach (T item in _newList)
            {
                await Repository<T>.CreateDocument(item);
            }

            foreach (int id in _deleteList)
            {
                await Repository<T>.DeleteDocument(id.ToString());
            }
        }

        public async Task<Person> FindPersonFromId(string id)
        {
            return await Repository<Person>.GetDocument(id);
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await Repository<Person>.GetDocuments();
        }
    }
}