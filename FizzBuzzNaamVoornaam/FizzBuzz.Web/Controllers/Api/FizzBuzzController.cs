using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using FizzBuzz.Web.Models;

namespace FizzBuzz.Web.Controllers.Api
{
    public class FizzBuzzController : ApiController//TODO: inherit from the correct base class
    {
        private readonly IFizzBuzzService _service;

        public FizzBuzzController(IFizzBuzzService service)
        {
            _service = service;
        }
        [Route("api/fizz/{fizzFactor}/buzz/{buzzFactor}")]
        public IHttpActionResult GetFizzBuzzText(int fizzFactor, int buzzFactor, int lastNumber = 100)
        {
            string fizzBuzzText;
            try
            {
                fizzBuzzText = _service.GenerateFizzBuzzText(fizzFactor, buzzFactor, lastNumber);
            }
            catch (FizzBuzzValidationException ex)
            {
                return BadRequest();
            }
            
            return Ok(fizzBuzzText);
        }
    }
}
