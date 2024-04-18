class Animal
{
    public string? Name {get; set;}
    public virtual void GetRoar()
    {
        System.Console.WriteLine("Some Roar");
    }
}

class Cat : Animal
{
    public override void GetRoar()
    {
        System.Console.WriteLine("Miyaw");
    }
}
class Dog : Animal
{
        public override void GetRoar()
    {
        System.Console.WriteLine("Gaf");
    }
}
class Rat : Animal
{
        public override void GetRoar()
    {
        System.Console.WriteLine("Krr");
    }
}
class Boozer : Animal
{
        public override void GetRoar()
    {
        System.Console.WriteLine("Normalno");
    }
}