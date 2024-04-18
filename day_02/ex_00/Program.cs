class Program
{
    static void Main(string[] args)
    {
        if (!checkInput(args))
        {
            System.Console.WriteLine("Input error. Check the input data and repeat the request.");
            return;
        }

        // “100 RUB” “path/to/folder”
        string[] sumParts = args[0].Split(' ');

        decimal amount = decimal.Parse(sumParts[0]); // 100
        string currency = sumParts[1];               // RUB
        string ratesDirectory = args[1];         // ./rates

        ExchangeSum exchangeSum = new(amount, currency);
        Exchanger exchanger = new(exchangeSum, ratesDirectory);
        IEnumerable<string> res = exchanger.ConvertAmount(amount);

        System.Console.WriteLine($"Amount in the original currency: {exchangeSum.ToString()}");
        foreach (var a in res)
        {
            System.Console.WriteLine(a);
        }
    }

    static bool checkInput(string[] args)
    {
        bool res = true;
        string[] inputArr = args[0].Split(' ');
        string pathToFile = $"{args[1]}/{inputArr[1]}.txt";
        if (!File.Exists(pathToFile) || args.Length != 2 || !int.TryParse(inputArr[0], out int inputNum))
        {
            res = false;
        }
        if (inputArr[1] != "RUB" && inputArr[1] != "EUR" && inputArr[1] != "USD") res = false;
        
        return res;
    }
}
