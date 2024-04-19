using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string jsonPath = args[0];
                int jsonPriority = int.Parse(args[1]);
                string yamlPath = args[2];
                int yamlPriority = int.Parse(args[3]);
                
                JsonSource json = new(jsonPath, jsonPriority);
                YamlSource yaml = new(yamlPath, yamlPriority);
                Configuration configuration = new(new List<IConfigurationSource> {json, yaml} );
                System.Console.WriteLine("Configuration");
                foreach (var item in configuration.Params)
                {
                    System.Console.WriteLine($"{item.Key}: {item.Value}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid data. Check your input and try again. \nError: {ex.Message}");
            }
        }
    }
}
