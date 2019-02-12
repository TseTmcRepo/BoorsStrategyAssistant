using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TsetmcLib
{
    public static class ObjectExtensions
    {
        public static T ToObject<T>(this IDictionary<string, object> source)
        where T : class, new()
        {
            try
            {
                var someObject = new T();
                var json = JsonConvert.SerializeObject(source, Newtonsoft.Json.Formatting.Indented);
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                someObject = JsonConvert.DeserializeObject<T>(json, settings);
                return someObject;
            }
            catch (Exception ex)
            {
                throw new Exception("mapp exception", ex);
            }
        }
    }
}
