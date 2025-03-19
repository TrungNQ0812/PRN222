namespace ExchangeRateService
{
    public class CurrencyExchange
    {
        public string Base {get; set;}
        public DateTime date { get; set;}
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
