namespace SimpleService.Services
{
    public interface IDatabaseHealthService
    {
        bool IsDatabaseHealthy();
    }

    public class DatabaseHealthService : IDatabaseHealthService
    {
        public bool IsDatabaseHealthy()
        {
            return true;
        }
    }
}
