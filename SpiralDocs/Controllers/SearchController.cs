using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpiralDocs.Sevices;
using SpiralDocs.Models;
using Microsoft.AspNetCore.Http; 

namespace SpiralDocs.Controllers
{
    [Route("api/Search")]
    [ApiController]
    public class SearchController : Controller
    {

        private DocsSearchService _docsSearch;

        /// <summary>
        /// Dependency Injection from Microsoft.Extensions.Configuration
        /// IConfiguration Interface. This configuration is loaded from the Startup.cs class. 
        /// Configuration is needed to instantiate a new DocSearchService object in this scope. 
        /// </summary>
        /// <param name="config"></param>
        public SearchController(IConfiguration config)
        {
            _docsSearch = new DocsSearchService(config);

        }

    
        /// <summary>
        /// Route at "api/Search/<searchquery>/" 
        /// Uses search service to return query results as application.json
        /// </summary>
        /// <param name="searchQuery">string query</param>
        /// <returns></returns>
        [HttpGet("{searchQuery}", Name = "SearchbyQuery")]
        public JsonResult Search(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                searchQuery = "*";

            var data = _docsSearch.Search(searchQuery);
            var jsonData = Json(data);
            var data0 = new SearchResultObject();

            return Json(data);
        }

        /// <summary>
        /// HTTP Post Method returning an Action Result (Ok Status Code) 
        /// Async Method
        /// </summary>
        /// <param name="files">IForm File to be uploaded</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var filePath = Path.GetTempFileName();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count = files.Count, size, filePath });

        }
    }
}