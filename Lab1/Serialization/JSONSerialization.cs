using Newtonsoft.Json;

namespace TestApplication
{
    class JSONSerialization : ISerializer
    {
        public string serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
