using Domain.Common.DTOs;

namespace Domain.Interfaces;

public interface ICompanyRepository
{
    public Task<CompanyDto> GetByIdAsync(int id);
}
