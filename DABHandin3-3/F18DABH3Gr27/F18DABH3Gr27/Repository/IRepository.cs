using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Configuration;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net;

//// Followed tutorial to create Repository:  https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-dotnet-application


namespace F18DABH3Gr27.Repository
{
    public interface IRepository<T> where T : class
    {
        void Initialize();
        Task CreateDatabaseIfNotExistsAsync();
        Task CreateCollectionIfNotExistsAsync();
        Task<IEnumerable<T>> GetPersonsAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetPersonAsync(string id);
        Task<Document> CreatePersonAsync(T item);
        Task<Document> UpdatePersonAsync(string id, T item);
        Task<Document> DeletePersonAsync(string id);
    }
}

