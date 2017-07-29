using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MAS.Core.Domain.Indent;
using MAS.Core.Interface.Application.Indent;

namespace MAS.Web.Controllers
{
    public class HomeController : Controller
    {
        IIendentService _IndentService;

        public HomeController(IIendentService indentService)
        {
            _IndentService = indentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
      
        
    }
}
