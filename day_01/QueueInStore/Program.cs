using ex_05;

int cashRegisterCount = 3;
int storageCapacity = 40;

Store Baisu = new(storageCapacity, cashRegisterCount);

int allCustomers = 10;
List<Customer> listCustomers = [];

for (int i =0; i < allCustomers; i++) 
{
    Customer customer = new("customer" + (i+1), i+1);

    // Fill cart for every customer
    int cartCapacity = 7;
    customer.FillCart(cartCapacity);

    // add to que 
    var minCustOnReg = customer.ChooseLeastGoods(Baisu.CashRegisters);
    minCustOnReg.Customers.Enqueue(customer);
    listCustomers.Add(customer);
}

int InQue = 0;
Baisu.CashRegisters.ForEach(cr => InQue += cr.Customers.Count);

while (Baisu.IsOpen() && InQue > 0)
{
    foreach (var cash_reg in Baisu.CashRegisters) 
    {
        if (cash_reg.Customers.Count == 0)
        {
            InQue = 0;
            break;
        }
        else
        {
            // InQue = cash_reg.Customers.Count;
            var customer = cash_reg.Customers.Dequeue();
            
            if (Baisu.Storage.GoodsInStorage - customer.GoodsInCart >=0)
            {
                Baisu.Storage.GoodsInStorage -= customer.GoodsInCart;
                int itemsInCashReg = 0;
                cash_reg.Customers.ToArray().ToList().ForEach( c => itemsInCashReg += c.GoodsInCart);

                // Print
                System.Console.Write($"{customer.ToString()} - {cash_reg.Name} (");
                System.Console.Write($"{cash_reg.Customers.Count} people with ");
                System.Console.Write($"{itemsInCashReg} items behind)");
                System.Console.WriteLine("");
            }
            else
            {
                System.Console.WriteLine("\nbefore="+customer.ToString());
                customer.GoodsInCart -= Baisu.Storage.GoodsInStorage;
                Baisu.Storage.GoodsInStorage = 0;
                System.Console.WriteLine(customer.ToString());
                break;
            }
            System.Console.WriteLine("GoodsInStorage=" + Baisu.Storage.GoodsInStorage);
        }
    }

}
System.Console.WriteLine("GoodsInStorage=" + Baisu.Storage.GoodsInStorage);
