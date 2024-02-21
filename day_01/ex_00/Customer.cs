public class Customer
{
    public string Name {get; private set;}
    public int SerialNum {get; private set;}
    public int GoodsInCart {get; set;}

    public Customer(string aName, int aSerialNum)
    {
        this.Name = aName;
        this.SerialNum = aSerialNum;
        GoodsInCart = 0;
    }

    public void FillCart(int capacity)
    {
        int minCapacity = 1;
        int maxCapacity = capacity;
        Random random = new();
        GoodsInCart = random.Next(minCapacity, maxCapacity);
    }

    public override string ToString()
    {
        return $"{Name}, customer #{SerialNum} ({GoodsInCart} items in cart)";
    }

    public static bool operator ==(Customer obj1, Customer obj2)
    {
        if (ReferenceEquals(obj1, obj2))
            return true;
        if (obj1 is null || obj2 is null)
            return false;
        return obj1.SerialNum == obj2.SerialNum && obj1.Name == obj2.Name;
    }

    
    public static bool operator !=(Customer obj1, Customer obj2)
    {
        return !(obj1 == obj2);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Customer other = (Customer)obj;
        return this.SerialNum == other.SerialNum && this.Name == other.Name;
    }

    public override int GetHashCode()
    {
        return SerialNum.GetHashCode() ^ Name.GetHashCode();
    }
}
