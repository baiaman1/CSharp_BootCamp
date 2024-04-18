class Chef
{
    public void MakeChicken()
    {
        System.Console.WriteLine("The Chef makes chicken");
    }
    protected void MakeSalad()
    {
        System.Console.WriteLine("The Chef makes salad");
    }
    public virtual void MakeSpecialDish()
    {
        System.Console.WriteLine("The Chef makes bbq ribs");
    }
}