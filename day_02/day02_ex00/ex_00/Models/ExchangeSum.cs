public struct ExchangeSum
{
    private decimal Amount { get; }
    public string Currency { get; }

    public ExchangeSum(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override string ToString()
    {
        return $"{Amount:N2} {Currency}";
    }
}