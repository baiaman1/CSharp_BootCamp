class ItalianChef : Chef
{
    public void MakePizza()
    {
        System.Console.WriteLine("The Italian chef makes Pizza");
    }

    public  override void  MakeSpecialDish()
    {
        System.Console.WriteLine("The Chef makes italian bbq ribs");
    }

    public void MakeItalianSalad()
    {
        // System.Console.WriteLine("The Italian chef makes Italian Salad");
        MakeSalad();
    }
}