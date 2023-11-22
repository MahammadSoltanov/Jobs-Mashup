using Application.Shared.Interfaces;
using Domain.Common.DTOs;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly IApplicationDbContext _context;

    public CompanyRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyDto> GetByIdAsync(int id)
    {
        var company = await _context.Companies.FindAsync(new object[] { id });

        //This logic can be separated to a different class but as the project is small and will remain so, it is not needed
        CompanyDto companyDto = new CompanyDto() { Id = company.Id, Name = company.Name, };

        return companyDto;
    }
}
