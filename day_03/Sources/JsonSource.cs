using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Day03
{
    public class JsonSource : IConfigurationSource
    {
    private readonly string filePath;
    public int Priority { get; private set; }

    public JsonSource(string filePath, int priority)
    {
        this.filePath = filePath;
        Priority = priority;
    }

    public Dictionary<string, string> LoadParameters()
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();

        string json = File.ReadAllText(filePath);
        using (JsonDocument doc = JsonDocument.Parse(json))
        {
            foreach(var property in doc.RootElement.EnumerateObject())
            {
                parameters[property.Name] = property.Value.ToString();
            }
        }
        return parameters;
    }

    }
}
