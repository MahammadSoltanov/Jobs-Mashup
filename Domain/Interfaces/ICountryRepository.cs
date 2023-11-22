using Domain.Common.DTOs;

namespace Domain.Interfaces;

public interface ICountryRepository
{
    public Task<CountryDto> GetByIdAsync(int id);
}
