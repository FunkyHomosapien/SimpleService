using System;

namespace SimpleService.Models
{
    public class HealthIndicator
    {
        public HealthIndicator(bool applicationHealthy, 
                               bool serverHealthy, 
                               bool databaseHealthy,
                               string hostname,
                               DateTime timestamp)
        {
            ApplicationHealthy = applicationHealthy;
            ServerHealthy = serverHealthy;
            DatabaseHealthy = databaseHealthy;
            Hostname = hostname;
            Timestamp = timestamp;
        }
        
        public bool SystemHealthy => ApplicationHealthy && DatabaseHealthy && ServerHealthy;
        public string Hostname { get; }

        public bool ApplicationHealthy { get; }
        public bool ServerHealthy { get; }
        public bool DatabaseHealthy { get; }

        public DateTime Timestamp { get; }
    }
}
