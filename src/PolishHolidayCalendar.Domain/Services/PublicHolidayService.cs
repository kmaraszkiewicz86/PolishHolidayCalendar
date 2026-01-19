using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Domain.Interfaces;
using PolishHolidayCalendar.Domain.Repositories;

namespace PolishHolidayCalendar.Domain.Services;

public class PublicHolidayService
{
    private readonly IPublicHolidayRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public PublicHolidayService(IPublicHolidayRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task SaveHolidaysAsync(IEnumerable<PublicHoliday> holidays)
    {
        _repository.Save(holidays);
        await _unitOfWork.SaveChangesAsync();
    }
}
