using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class Shortcuts
    {
        public static JTask MapAsync(this JObject jObject) => new JTask(jObject);
        public static int Id(this JObject jObject) => (int)jObject["id"];
    }
}
