// decimal num = 0;
// for (int i = 0; i < 10; i++)
// {
//     num += 0.1m;
//     System.Console.WriteLine(i+1);
// }
// System.Console.WriteLine(num);

// int a = 2, b = 3;
// System.Console.WriteLine(a%b);

// var isA = false;
// var isB = false;
// var isC = true;

// if (isA || isB && isC) System.Console.WriteLine("one");
// if (isA | isB & isC) System.Console.WriteLine("two");

// string[] arr = new string [4];
// arr[0] = "Hello";


// int a = 5;
// int b = a;
// b = 0;
// Console.WriteLine($"a: {a} b: {b}");

var s1 = "hello";
var s2 = s1;
Console.WriteLine($"s2: {s2}");
s1 = "world";
Console.WriteLine($"s2: {s2}");

string[] arr1 = ["hello"];
string[] arr2 = arr1;
System.Console.WriteLine(arr2[0]);
arr1[0] = "world";
System.Console.WriteLine(arr2[0]);
