using System.Web.Http.Results;
using System.Web.Mvc;
using FizzBuzz.Web.Models.FizzBuzzViewModels;

namespace FizzBuzz.Web.Controllers
{
    public class HomeController : Controller //TODO: inherit from the correct base class
    {
        public HomeController()
        {
            
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(FizzBuzzViewModel.CreateDefault());
        }

        public ActionResult Index(FizzBuzzViewModel postedModel)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            return View(postedModel);
        }
    }
}