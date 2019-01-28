using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpiralDocs.Services;
using SpiralDocs.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations; 

namespace SpiralDocs.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class DocumentsController : Controller
    {
        private readonly SpiralDocService _docService;
        
        public DocumentsController(SpiralDocService DocService)
        {
            _docService = DocService; 
        }

        public ActionResult<List<SpiralDoc>> Index()
        {
            return View(_docService.Get().ToList());
        }

        public IActionResult Browse()
        {
            return View("DocuBrowse"); 
        }


        //public IActionResult Index()
        //{
        //    ViewData["Title"] = "Index";

        //    return View();
        //}
    }
}