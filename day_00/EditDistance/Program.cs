
void Print() {
    string filePath = "us_names.txt";
    if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                Console.Write("Enter name: ");
                string? name = Console.ReadLine();
                bool find = false;
                if (name != null)
                while ((line = reader.ReadLine()) != null)
                {
                    if (line==name) 
                    {
                        Console.WriteLine($"Hello, {name}!");
                        find = true;
                        break;
                    }
                }

                if(!find) 
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (name != null)
                        if (LevenDis(name, line)==1) 
                        {
                            Console.WriteLine($"Did you mean “{line}”? Y/N");
                            string? answ = Console.ReadLine();
                            if(answ=="Y" || answ == "y") 
                            {
                                Console.WriteLine($"Hello, {line}!");
                                find = true;
                                break;
                            }
                        }
                    }
                    if(!find) Console.WriteLine("Your name was not found.");
                }
            }
        }
        else
        {
            Console.WriteLine("Файл не найден.");
        }

}
// int a = 'a' - 32;
string str = "q";
str += char(str[0]-32);
System.Console.WriteLine(str);

// Print();

int LevenDis(string s, string t)
{
    int m = s.Length;
    int n = t.Length;
    int[,] d = new int[m + 1, n + 1];

    // Инициализация первой строки и столбца
    for (int i = 0; i <= m; i++)
    {
        d[i, 0] = i;
    }
    for (int j = 0; j <= n; j++)
    {
        d[0, j] = j;
    }

    // Вычисление расстояния Левенштейна
    for (int j = 1; j <= n; j++)
    {
        for (int i = 1; i <= m; i++)
        {
            int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
            d[i, j] = Math.Min(
                Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                d[i - 1, j - 1] + cost
            );
        }
    }

    return d[m, n];
}