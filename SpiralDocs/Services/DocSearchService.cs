using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace SpiralDocs.Services
{
    /// <summary>
    /// Service class implementing Azure Search functionality to query Azure Blob Storage for Files
    /// </summary>
    public class DocsSearchService
    {
        private static ISearchIndexClient _indexClient;
        private static ISearchServiceClient _searchClient;

        public static string errorMessage;

        /// <summary>
        /// Constructor of Document Search Service. 
        /// Service Implements Azure storage to query Blob Storage for Documents 
        /// </summary>
        /// <param name="config"> Dependency Injection of Configuration Manager IConfiguration </param>
        public DocsSearchService(IConfiguration config)
        {
            try
            {
                string searchServiceName = config.GetSection("AzureSearch")["SearchServiceName"];
                string adminApiKey = DocsSearchService.APIKey(config);
                _searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
                //_indexClient = _searchClient.Indexes.GetClient("spiraldocsindex");
                _indexClient = _searchClient.Indexes.GetClient("azureblob-index3");
            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
            }
        }

        public DocumentSearchResult Get()
        {
            SearchParameters sp = new SearchParameters()
            {
                SearchMode = SearchMode.All,
                QueryType = QueryType.Simple,
                Select = new[] { "people", "metadata_storage_path", "metadata_storage_name", "organizations", "locations", "keyphrases" },
                Top = 15
            };
            var searchFound = _indexClient.Documents.Search("", sp);
            return searchFound;
        }

        public DocumentSearchResult Search(string searchText)
        {
            try
            {
                SearchParameters sp = new SearchParameters()
                {
                    SearchMode = SearchMode.Any,
                    IncludeTotalResultCount = false,
                    QueryType = QueryType.Simple,
                    Select = new[] { "people", "metadata_storage_path", "metadata_storage_name", "organizations", "locations", "keyphrases" },
                    Top = 5
                };
                return _indexClient.Documents.Search(searchText, sp);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message.ToString();
            }
            return null;
        }

        private static SearchServiceClient CreateSearchServiceClient(IConfiguration configuration)
        {
            string searchServiceName = configuration["SearchServiceName"];
            string adminApiKey = configuration["SearchServiceAdminApiKey"];

            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
            return serviceClient;
        }

        /// <summary>
        /// Returns the secret for the Azure Search Account 
        /// </summary>
        /// <param name="config"> Dependency Injection using IConfiguration</param>
        /// <returns></returns>
        private static string APIKey(IConfiguration config)
        {
            return config["Search:UserKey1"];
        }

    }
}
