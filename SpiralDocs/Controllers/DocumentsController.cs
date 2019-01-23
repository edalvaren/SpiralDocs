using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpiralDocs.Sevices; 

namespace SpiralDocs.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly SpiralDocService _docService; 
        public IActionResult Index()
        {
            ViewData["Title"] = "Index";

            return View();
        }
    }
}