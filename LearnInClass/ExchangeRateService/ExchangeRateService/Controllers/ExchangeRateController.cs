using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : Controller
    {

        [HttpGet]
        [Route("GetLastestRates")]
        public CurrencyExchange GetLastestRates()
        {
            var rates = new Dictionary<string, Decimal>();
            rates.Add("CAD", 1.260046m);
            rates.Add("CHF", 0.933058m);
            rates.Add("EUR", 0.806942m);
            rates.Add("GBP", 0.719154m);

            CurrencyExchange currencyExchange = new CurrencyExchange
            {
                Base = "USD",
                date = DateTime.Now,
                Rates = rates
            };

            return currencyExchange;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
