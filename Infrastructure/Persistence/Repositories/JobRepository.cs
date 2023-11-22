using Application.Shared.Interfaces;
using Domain.Common.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class JobRepository : IJobRepository
{
    private readonly IApplicationDbContext _context;
    private readonly ICompanyRepository _companyRepository;
    private readonly ICountryRepository _countryRepository;

    public JobRepository(IApplicationDbContext context, ICompanyRepository companyRepository, ICountryRepository countryRepository)
    {
        _context = context;
        _companyRepository = companyRepository;
        _countryRepository = countryRepository;
    }

    public async Task<List<JobDto>> GetAllAsync()
    {
        var jobs = await _context.Jobs.ToListAsync();
        List<JobDto> jobDtos = new List<JobDto>();

        if (jobs.Any())
        {
            foreach (var job in jobs)
            {
                var companyName = (await _companyRepository.GetByIdAsync(job.CompanyId)).Name;
                var countryName = (await _countryRepository.GetByIdAsync(job.CountryId)).Name;

                JobDto jobDto = new JobDto()
                {
                    Id = job.Id,
                    Position = job.Position,
                    JobLink = job.JobLink,
                    PublishDate = job.PublishDate,
                    CompanyName = companyName,
                    CountryName = countryName
                };

                jobDtos.Add(jobDto);
            }
        }

        return jobDtos;
    }

}
