using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FizzBuzz.Web.Controllers
{
    [Authorize(Users = "admin@pxl.be")]
    public class SecretController :Controller //TODO: inherit from the correct base class
    {
        public ActionResult Secret1()
        {
            return Content("Top secret 1");
        }

        public ActionResult Secret2()
        {
            return Content("Top secret 2");
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult Gossip()
        {
            return Content(Guid.NewGuid().ToString());
        }
    }
}