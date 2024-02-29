using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    public class Configuration
    {
        public Dictionary<string, string> Params { get; private set; }

        public Configuration(IEnumerable <IConfigurationSource> sources)
        {
            Params = [];

            foreach (var source in sources.OrderBy(s => s.Priority))
            {
                var parameters = source.LoadParameters();
                foreach(var parameter in parameters)
                {
                    Params[parameter.Key] = parameter.Value;
                }
            }
        }
        
    }
}