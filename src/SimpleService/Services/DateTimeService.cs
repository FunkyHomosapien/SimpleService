using System;
namespace SimpleService.Services
{
    public interface IDateTimeService
    {
        DateTime Now();
        DateTime UtcNow();
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
