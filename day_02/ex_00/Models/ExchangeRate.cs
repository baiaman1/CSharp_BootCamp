// public struct ExchangeRate
// {
//     public string FromCurrency { get; } //Валюта От  RUB
//     public string ToCurrency { get; } // Валюта До   USD
//     public decimal Rate { get; } // Курс обмена    0,013569 

//     public ExchangeRate(string fromCurrency, string toCurrency, decimal rate)
//     {
//         FromCurrency = fromCurrency;
//         ToCurrency = toCurrency;
//         Rate = rate;
//     }
// }


public struct ExchangeRate
{
    public string FromCurrency { get; }
    public string ToCurrency { get; }
    public decimal Rate { get; }

    public ExchangeRate(string fromCurrency, string toCurrency, decimal rate)
    {
        FromCurrency = fromCurrency;
        ToCurrency = toCurrency;
        Rate = rate;
    }
}
