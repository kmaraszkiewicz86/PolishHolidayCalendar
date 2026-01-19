namespace PolishHolidayCalendar.Domain.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
