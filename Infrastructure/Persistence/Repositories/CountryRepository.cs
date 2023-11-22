using Application.Shared.Interfaces;
using Domain.Common.DTOs;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly IApplicationDbContext _context;

    public CountryRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CountryDto> GetByIdAsync(int id)
    {
        var country = await _context.Countries.FindAsync(new object[] { id });

        //This logic can be separated to a different class but as the project is small and will remain so, it is not needed
        CountryDto countryDto = new CountryDto() { Id = country.Id, Name = country.Name, };

        return countryDto;
    }
}
