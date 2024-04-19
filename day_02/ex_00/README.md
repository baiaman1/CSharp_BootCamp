## Exercise 00 – How much money does money cost?

“Engineering is a profession that can do the job of almost all other professions.”

**― Amit Kalantri, Wealth of Words**

### What's new

- Structs
- Override
- String interpolation
- System.IO

### Project structure:
```
d02_ex00
      Program.cs
      Exchanger.cs
      Models
            ExchangeRate.cs
            ExchangeSum.cs
```

### The objective

You are already guided by the principles of **SOLID** in development and break your code into **classes** and **structs**.

Your next challenge is the implementation of a currency converter for EUR-RUB, USD-RUB, EUR-USD, USD-EUR, RUB-USD, RUB-EUR pairs. At the input, the program will request an amount in one of the permitted currencies (EUR, RUB, USD). In response, it will display a table that contains the amounts converted into other permitted currencies. For convenience, we determine that each currency has its own unique identifier code (EUR, RUB, USD). For data representation, **structs** are suitable: then for the amount in the currency, you can define *ExchangeSum* (amount, identifier), and for exchange information - *ExchangeRate* (currency "from”, currency "to", exchange rate).

Use the **single-responsibility principle**! According to it, your structs should not be aware of other currencies and exchange rates. But they can independently parse data from text or define the format of output data when casting to a string. **Overriding** the ToString() method can help you. 

Information about the exchange rates is provided by the exchanger / stock exchange. In the archive attached to the exercise, you will find files with conversion ratios. We assume that the data format in the file is strictly specified. The files are supposed to be updated once a day, so the folder path will be one of the input arguments.

The functionality of the exchanger should be separated into a separate *Exchanger* class. It will contain a collection of exchange rates, parse them from files and convert them. Remember, *Exchanger* does not need to know where it is called from and what the result is used for - do not make it responsible for outputting to the terminal.

If the conversion method returns a list of possible amounts in the currency, its use will be much more flexible.

Look into the **yield** statement, it can be useful. 

|Argument|Type|Description|
|---|---|---|
| sum |string | Amount with currency indication |
|ratesDirectory | string | The path to the folder with files with conversion rates|

### Output format
```
Amount in the original currency: 100.00 RUB
Amount in USD: 1.36 USD
Amount in EUR: 1.11 EUR

Amount in the original currency: 100.00 EUR
Amount in USD: 81.97 USD
Amount in RUB: 8,990.38 RUB
```

### The user specified incorrect data
```
Input error. Check the input data and repeat the request.
```

### Example of launching an application from the project folder

```
$ dotnet run “100 RUB” “path/to/folder”
Amount in the original currency: 100.00 RUB
Amount in USD: 1.36 USD
Amount in EUR: 1.11 EUR
```
