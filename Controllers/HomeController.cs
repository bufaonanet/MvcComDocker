using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvcComDocker.context.repositories;
using MvcComDocker.Models;

namespace MvcComDocker.Controllers
{
    public class HomeController : Controller
    {
        private  readonly IRepository _repository;
        private string message;

        public HomeController(IRepository repository, IConfiguration config)
        {
            _repository = repository;
            message = $"Docker - ({config["HOSTNAME"]})";             
        }

        public IActionResult Index()
        {
            ViewBag.Message = message;
            return View(_repository.Produtos);
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
