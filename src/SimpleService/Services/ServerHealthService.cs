namespace SimpleService.Services
{
    public interface IServerHealthService
    {
        bool IsServerHealthy();
        string Hostname { get; }
    }

    public class ServerHealthService : IServerHealthService
    {
        public ServerHealthService(IMachineInfo machineInfo)
        {
            Hostname = machineInfo.GetHostname();
        }

        public bool IsServerHealthy()
        {
            return true;
        }

        public string Hostname { get; }
    }
}
