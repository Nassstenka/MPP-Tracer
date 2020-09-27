using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace MyTracer
{
    [DataContract(Name = "Result")]
    public class TraceResult
    {
        [DataMember(Order = 1)]
        public ConcurrentDictionary<int, ThreadInfo> threadDict { get; }
        [DataMember(Order = 0)]
        public double executionTime;
        public TraceResult()
        {
            threadDict = new ConcurrentDictionary<int, ThreadInfo>();
        }
        public void GetExecutionTime()
        {
            executionTime = 0;
            foreach (KeyValuePair<int, ThreadInfo> pair in threadDict)
            {
                pair.Value.GetThreadExecutionTime();
                executionTime += pair.Value.executionTime;
            }
        }
    }

    [DataContract(Name = "Thread")]
    public class ThreadInfo
    {
        [DataMember(Order = 0)]
        public int ID { get; set; }
        [DataMember(Order = 2)]
        public List<MethodInfo> methods { get; set; }
        public Stack<MethodInfo> methodStack { get; set; }
        [DataMember(Order = 1)]
        public double executionTime { get; set; }
        public ThreadInfo(int ID)
        {
            this.ID = ID;
            methods = new List<MethodInfo>();
            methodStack = new Stack<MethodInfo>();
        }
        public void GetThreadExecutionTime()
        {
            executionTime = 0;
            foreach(MethodInfo method in methods)
            {
                double innerExecutionTime = 0;
                foreach (MethodInfo innerMethod in method.innerMethods)
                {
                    innerExecutionTime += innerMethod.GetExecutionTime();
                }
                executionTime += method.GetExecutionTime() + innerExecutionTime;
            }
        }
    }

    [DataContract(Name = "Method")]
    public class MethodInfo
    {
        private Stopwatch stopwatch;
        [DataMember(Order = 0)]
        public string methodName { get; set; }
        [DataMember(Order = 1)]
        public string className { get; set; }
        [DataMember(Order = 3)]
        public List<MethodInfo> innerMethods { get; set; }
        [DataMember(Order = 2)]
        public double executionTime { get; set; }
        public MethodInfo(string methodName, string className)
        {
            innerMethods = new List<MethodInfo>();
            stopwatch = new Stopwatch();
            this.methodName = methodName;
            this.className = className;
        }
        public void AddChildren(MethodInfo methodInfo)
        {
            bool isExists = false;
            foreach(MethodInfo innerMethod in innerMethods)
            {
                if (methodInfo == innerMethod)
                {
                    isExists = true;
                }
            }
            if (!isExists)
            {
                innerMethods.Add(methodInfo);
            }
        }
        public void StartCheckingTime()
        {
            stopwatch.Start();
        }
        public void StopCheckingTime()
        {
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;
        }
        public double GetExecutionTime()
        {
            return executionTime;
        }
    }
}
