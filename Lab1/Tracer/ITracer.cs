namespace MyTracer
{
    interface ITracer
    {
        public void StartTrace();
        public void StopTrace();
        TraceResult GetTraceResult();
    }
}
