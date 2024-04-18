

Animal[] animals = new Animal[4];

Cat cat = new();
cat.Name = "Liza";

Dog dog = new();
dog.Name = "Aktosh";

Rat rat = new();
rat.Name = "Pit";

Boozer boozer = new()
{
    Name = "Vasya"
};

animals[0] = cat;
animals[1] = dog;
animals[2] = rat;
animals[3] = boozer;

foreach (var animal in animals)
{
    System.Console.WriteLine($"Animal {animal.Name} say:");
    animal.GetRoar();
}
