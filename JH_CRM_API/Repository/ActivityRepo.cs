using JH_CRM_API.Models;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace JH_CRM_API.Repository
{
    public class ActivityRepo
    {
        private static DocumentClient client = new DocumentClient(new Uri(WebConfigurationManager.AppSettings["CosmosDBEndpoint"]), WebConfigurationManager.AppSettings["CosmosDBApiKey"]);
        private static string database = WebConfigurationManager.AppSettings["Database"];
        private static string collection = WebConfigurationManager.AppSettings["Collection"];

        public static async Task<bool> insertActivityDocument(Activity document)
        {
            try
            {
                await client.CreateDocumentAsync(
            UriFactory.CreateDocumentCollectionUri(database, collection), document);
                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Error querying DB: {0}\r\n", exception.Message.ToString());
                throw exception;
            }
        }


        public static async Task<bool> updateActivityDocument(Activity document)
        {
            try
            {
                await client.ReplaceDocumentAsync(
            UriFactory.CreateDocumentUri(database, collection, document.id), document);
                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Error querying DB: {0}\r\n", exception.Message.ToString());
                throw exception;
            }
        }

        public static async Task<Activity> getActivityDocument(string id)
        {
            try
            {
                Activity result = await client.ReadDocumentAsync<Activity>(UriFactory.CreateDocumentUri(database, collection, id));
                return result;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Error querying DB: {0}\r\n", exception.Message.ToString());
                //throw exception;
                return null;
            }

        }

        public static List<Activity> getActivityDocuments()
        {
            try
            {
                // return await client.ReadDocumentFeedAsync(UriFactory.CreateDocumentCollectionUri(database, collection), new FeedOptions { MaxItemCount = 10 });
                return client.CreateDocumentQuery<Activity>(UriFactory.CreateDocumentCollectionUri(database, collection)).Take(20).ToList();
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Error querying DB: {0}\r\n", exception.Message.ToString());
                throw exception;
            }
        }

        public static async Task<List<KeywordResult>> getKeywords()
        {
            try
            {
                var query = from d in client.CreateDocumentQuery<Activity>(UriFactory.CreateDocumentCollectionUri(database, collection))                        
                            select d.keywords;
                //   return query.ToList().SelectMany(x=>x).ToList().GroupBy(g => g).ToDictionary(x => x.Key, x => x.Count()); ;

                return query.ToList().SelectMany(x => x).ToList().GroupBy(g => g).Select(s => new KeywordResult
                {
                    text = s.Key,
                    weight = s.Count()
                }).ToList();
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Error querying DB: {0}\r\n", exception.Message.ToString());
                throw exception;
            }
        }
    }
}