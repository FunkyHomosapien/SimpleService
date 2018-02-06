namespace SimpleService.Services
{
    public interface IMachineInfo
    {
        string GetHostname();
    }

    public class MachineInfo : IMachineInfo
    {
        public string GetHostname()
        {
            return System.Net.Dns.GetHostName();
        }
    }
}