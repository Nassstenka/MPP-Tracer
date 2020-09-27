using MyTracer;
using Newtonsoft.Json;

namespace TestApplication
{
    class JSONSerialization : ISerializer
    {
        public string serialize(TraceResult traceResult)
        {
            return JsonConvert.SerializeObject(traceResult, Formatting.Indented);
        }
    }
}
