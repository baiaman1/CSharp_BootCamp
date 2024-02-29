using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace Day03
{
    public class YamlSource : IConfigurationSource
    {
        private readonly string filePath;
        public int Priority { get; private set; }

        public YamlSource(string filePath, int priority)
        {
            this.filePath = filePath;
            Priority = priority;
        }

        public Dictionary<string, string> LoadParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            var deserializer = new Deserializer();
            
            using (var reader = new StreamReader(filePath))
            {
                var yamlObject = deserializer.Deserialize(reader);
                if (yamlObject != null && yamlObject is Dictionary<object, object> dict)
                {
                    if(dict != null)
                    {
                        foreach (var item in dict)
                        {
                            string key = item.Key.ToString() ?? "";
                            string value = item.Value.ToString() ?? "";
                            parameters[key] = value;
                        }
                    }
                }
            }

            return parameters;
        }
    }
}