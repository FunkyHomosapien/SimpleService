namespace SimpleService.Services
{
    public interface IApplicationHealthService
    {
        bool IsApplicationHealthy();
    }

    public class ApplicationHealthService : IApplicationHealthService
    {
        public bool IsApplicationHealthy()
        {
            return true;
        }
    }
}
