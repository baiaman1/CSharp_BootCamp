using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Exchanger
{
    private readonly List<ExchangeRate> ExchangeRates;

    private string Sum {get;} // 100 from imput “100 RUB” “path”

    public Exchanger(ExchangeSum input, string ratesDirectory)
    {
        this.Sum = input.Currency;

        ExchangeRates = [];
        LoadExchangeRates(ratesDirectory);
    }
    

    private void LoadExchangeRates(string folderPath)
    {
        string pathToFile = $"{folderPath}/{Sum}.txt";
        
        string[] lines = File.ReadAllLines(pathToFile);
        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            
            if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal rate))
            {
                ExchangeRates.Add(new ExchangeRate(Sum, parts[0], rate));
            }
        }
        
    }

    public IEnumerable<string> ConvertAmount(decimal amount)
    {
        for (int i = 0; i < 2; i++)
        {
            var eRate = ExchangeRates[i];
            var res = eRate.Rate * amount;

            // Amount in USD: 1.36 USD
            yield return $"Amount in {eRate.ToCurrency}: {res:N2} {eRate.ToCurrency}";
        }
    }


    







}









    // private List<ExchangeRate> exchangeRates;
        // exchangeRates = new List<ExchangeRate>();
        // LoadExchangeRates(folderPath, fromInCurr);




// }
