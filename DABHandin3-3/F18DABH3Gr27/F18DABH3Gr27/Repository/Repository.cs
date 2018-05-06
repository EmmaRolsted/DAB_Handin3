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


// Followed tutorial to create Repository:  https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-dotnet-application

namespace F18DABH3Gr27.Repository
{
    public static class Repository<T> where T : class
    {
        private static readonly string DatabaseId = ConfigurationManager.AppSettings["database"];
        private static readonly string CollectionId = ConfigurationManager.AppSettings["collection"];
        private static DocumentClient client;


        public static void Initialize()
        {
            //See Web-config files for information...
            client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["endpoint"]), ConfigurationManager.AppSettings["authKey"]);
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollectionIfNotExistsAsync().Wait();
        }
        
        // Creating DB if it does not already exist! /with name from web.config file
        private static async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }
        // Creating DB collection if it does not already exist! /with name from web.config file
        private static async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }
        //GET: Get alle people from the database
        public static async Task<IEnumerable<T>> GetPersonsAsync(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId))
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        //GET: Get specific person (id) from the database
        public static async Task<T> GetPersonAsync(string id)
        {
            try
            {
                Document document = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return (T)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
        //POST: (Add person)
        public static async Task<Document> CreatePersonAsync(T item)
        {
            //try
            //{
            //    await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
            //}
            //catch (DocumentClientException e)
            //{
            //    if (e.StatusCode == HttpStatusCode.NotFound)
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
        }

        //PUT: (Update an existing resource(Person))
        public static async Task<Document> UpdatePersonAsync(string id, T item)
        {
            //try
            //{
            //    await client.ReplaceDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId, id), item);
            //}
            //catch (DocumentClientException e)
            //{
            //    if (e.StatusCode == HttpStatusCode.NotFound)
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }

        //DELETE: Delete a person from database
        public static async Task DeletePersonAsync(string id)
        {

            await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }


        
    }
}