namespace ToDo
{
    class Program
    {
static void Main(string[] args)
{

    // string str1 = "";
    // string str2 = str1;

    // str1 = "first";
    // str2 = "second";
    // System.Console.WriteLine(str1);
    // System.Console.WriteLine(str2);


    Person person1 =  new();
    Person person2 =  person1;

    person1.Name = "Baiaman";
    person2.Name = "Nur";
    Console.WriteLine($"person1={person1.Name}");
    Console.WriteLine($"person2={person2.Name}");
}
        static void printObj(Person person)
        {
            person.Name = "Kenesh";
        }

        static void printInt(int num)
        {
            num = 5;
        }

        static void printStr(string str)
        {
            str = "changed success";
        }
    }

    public class Person
    {
        public string Name { get; set; } = "";
    }
}