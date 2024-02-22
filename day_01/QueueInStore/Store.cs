public class Store
{
    public Storage Storage {get;}
    public List<CashRegister> CashRegisters { get; private set; }

    public Store(int storageCapacity, int numOfCashRegisters)
    {
        Storage = new Storage(storageCapacity);
        CashRegisters = new List<CashRegister>();
        for (int i = 1; i <= numOfCashRegisters; i++)
        {
            CashRegisters.Add(new CashRegister("Cash Register #" + i));
        }
    }
    public bool IsOpen()
    {
        return !Storage.IsEmpty();
    }
}