using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using F18DABH3Gr27.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace F18DABH3Gr27.Repository
{
    public static class Repository<T> where T : class
    {
        //private static DocumentClient _client;

        //private const string EndpointUrl = "https://localhost:8081";

        //private const string PrimaryKey =
        //    "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="; //Key for local DB emulator


        //private static string DatabaseId = "PersonKartotekDB"; //Name of database and collection
        private static string CollectionId = "PersonKartotek";


        private const string EndpointUrl = "https://localhost:8081";

        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";   //Key for local DB emulator

        public static string DatabaseId = "PersonKartotek";    //Name of database and collection

        //public static readonly string DatabaseId = ConfigurationManager.AppSettings["databaseName"]; //See web.config file for info
        //public static readonly string CollectionId = ConfigurationManager.AppSettings["collectionName"]; //See web.config file for info
        //public string CollectionName = "PersonCollection3";

        private static DocumentClient _client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);

        public static async Task CreateDB()
        {
            await _client.CreateDatabaseIfNotExistsAsync(new Database {Id = DatabaseId}); //Create new database
            DocumentCollection collection = new DocumentCollection();
            //collection.Id = CollectionId;
            collection.PartitionKey.Paths.Add("/id");

            await _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId),
                collection); //Create collection  
        }

        public static async Task<T> GetDocument(string id)
        {
            try
            {
                Document result =
                    await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return (T) (dynamic) result; //will be resolves at run-time

            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                else throw;
            }
        }

        public static async Task<IEnumerable<T>> GetDocuments()
        {
            IDocumentQuery<T> queryable = _client
                .CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                    new FeedOptions {MaxItemCount = -1}).AsDocumentQuery();

            List<T> resulstList = new List<T>();
            while (queryable.HasMoreResults)
            {
                resulstList.AddRange(await queryable.ExecuteNextAsync<T>());
            }

            return resulstList;
        }

        public static async Task<Document> CreateDocument(T item)
        {
            return await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                item);

        }

        public static async Task<Document> UpdateDocument(string id, T item)
        {
            return await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id),
                item);
            //return await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }

        public static async Task DeleteDocument(string id)
        {
            await _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }

        //private static Person InitPerson()
        //{
        //    Person arminaPerson = new Person
        //    {
        //        Id = "Armina.8",
        //        Firstname = "Armina",
        //        MiddleName = "Isabella",
        //        LastName = "Sanjari",


        //        Email = new Email
        //        {
        //            EmailAddress = "armina1506@hotmail.com",
        //            EmailType = "privat"

        //        },
        //        PhoneNR = new PhoneNR
        //        {
        //            PhoneNumber = "27289764",
        //            PhoneType = "privat",
        //            PhoneCompany = "nej"
        //        },

        //        PrimaryAddress = new PrimaryAddress
        //        {
        //            Type = "privat",
        //            CityName = "Aarhus",
        //            HouseNumber = "6",
        //            StreetName = "Haslevej",
        //            ZipCode = "8000"

        //        },

        //        AltAddress = new AltAddress
        //        {
        //            AltAddressType = "skole",
        //            CityName = "katrinebjerg",
        //            HouseNumber = "46",
        //            StreetName = "finderupvej",
        //            ZipCode = "8200"
        //        },

        //    };


        //    return arminaPerson;

        //}
    }
}

//        public IEnumerable<Person> GetAll()
//        {
//            IQueryable<Person> query = _client
//                .CreateDocumentQuery<Person>(UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName));

//            List<Person> results = new List<Person>();
//            foreach (var person in query)
//            {
//                results.Add(person);
//            }

//            return results;
//        }

//        internal Person Get(string id)
//        {
//            IQueryable<Person> query = _client
//                .CreateDocumentQuery<Person>(UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName))
//                .Where(p => p.Id == id);

//            Person pe = new Person();
//            foreach (var person in query)
//            {
//                pe = person;
//            }
//            return pe;
//        }

//        public async void Insert(Person person)
//        {
//            try
//            {
//                this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName),
//                    person).Wait();
//            }
//            catch (Exception e)
//            {
//                Debug.WriteLine("Cant insert new person: " + e.Message);
//            }
//        }

//        internal async void Put(string id, Person newPerson)
//        {
//            this._client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseName, CollectionName, id), newPerson).Wait();
//        }

//        public void Save()
//        {

//        }

//        public async void Delete(string id)
//        {
//            this._client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseName, CollectionName, id)).Wait();
//        }
//    }
//}