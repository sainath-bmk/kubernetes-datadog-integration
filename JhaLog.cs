using System;

namespace DatadogKubernetes
{
    public class JhaLog
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
        public string EventDateTime { get; set; }
        public string MessageFormat { get; set; }
        public string MessageType { get; set; }
        public string RequestId { get; set; }
        public string ServerTimeZone { get; set; }
        public string ProductName { get; set; }
        public string ApplicationName { get; set; }
        public string ProcessId { get; set; }
        public string ThreadId { get; set; }
        public string CorrelationId { get; set; }
        public string BusinessCorrelationId { get; set; }
        public string WorkflowCorrelationId { get; set; }
        public string IPAddress { get; set; }
        public string ClientTimeZone { get; set; }

    }
}
