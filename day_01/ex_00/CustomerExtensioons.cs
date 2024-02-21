using System;   


namespace ex_05
{
    public static class CustomerExtensions
    {
        public static CashRegister ChooseLeastCustomers(this Customer customer, List<CashRegister> cashRegisters)
        {
            return cashRegisters.OrderBy(cr => cr.Customers.Count).First();
        }
        
        public static CashRegister ChooseLeastGoods(this Customer customer, List<CashRegister> cashRegisters)
        {
            var selectedCashRegister = cashRegisters.OrderBy(cr => cr.Customers.Sum(c => c.GoodsInCart)).First();
            return selectedCashRegister;
        }
    }
    
}