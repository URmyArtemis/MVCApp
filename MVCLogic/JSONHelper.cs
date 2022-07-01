using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MVCLogic
{
    public static class JSONHelper
    {
        public static string ToJSON<T>(this T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
