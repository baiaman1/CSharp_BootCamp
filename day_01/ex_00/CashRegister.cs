using System;

public class CashRegister
{
    public Queue<Customer> Customers = new Queue<Customer>() ;
    public string Name { get; }

    public CashRegister(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        if (ReferenceEquals(this, obj))
        {
            return true;
        }
        return Name == ((CashRegister)obj).Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
