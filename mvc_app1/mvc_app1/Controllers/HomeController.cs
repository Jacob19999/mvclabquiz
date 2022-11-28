// Written By Jacob Tang


using Microsoft.AspNetCore.Mvc;
using mvc_app1.Models;
using System.Data;
using System.Diagnostics;

namespace mvc_app1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public ActionResult Persons()
        {

            // Using Visual basic CSV import function and import data into a datatable . Parse datatable into a list of employee objects.
            // MVC to render table of employee objects.

            List<PersonModel> PersonsList = new List<PersonModel>();

            var persons = new mvc_app1.Models.Person();

            PersonsList = persons.UpdateDT(persons.updatePersons("C:/Users/tngzj/Desktop/CS122/mvc_lab_Quiz/Mayflower.csv") );

            return View(PersonsList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}