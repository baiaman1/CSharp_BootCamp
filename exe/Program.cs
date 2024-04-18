object obj1 = 1;
object obj2 = obj1;
System.Console.WriteLine($"obj1={obj1} type={obj1.GetType()} obj2={obj2}");
obj1 = "hello";
System.Console.WriteLine($"obj1={obj1} type={obj1.GetType()} obj2={obj2}");
