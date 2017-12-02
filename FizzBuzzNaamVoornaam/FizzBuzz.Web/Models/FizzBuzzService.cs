using System.Text;

namespace FizzBuzz.Web.Models
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private IFizzBuzzValidator _validator;

        public FizzBuzzService(IFizzBuzzValidator validator)
        {
            _validator = validator;
        }
        public string GenerateFizzBuzzText(int fizzFactor, int buzzFactor, int lastNumber)
        {
            try
            {
                _validator.Validate(fizzFactor, buzzFactor, lastNumber);
            }
            catch (FizzBuzzValidationException ex)
            {
                throw new FizzBuzzValidationException(ex.Message);
            }
            string fizzBuzzText = "1";
            for (int i = 2; i <= lastNumber; i++)
            {
                if (i % fizzFactor == 0 && i % buzzFactor == 0)
                {
                    fizzBuzzText += " FizzBuzz";
                }
                else if (i % fizzFactor == 0)
                {
                    fizzBuzzText += " Fizz";
                }
                else if (i % buzzFactor == 0)
                {
                    fizzBuzzText += " Buzz";
                }
                else
                {
                    fizzBuzzText += " " + i;
                }
            }
            return fizzBuzzText;
        }
    }
}