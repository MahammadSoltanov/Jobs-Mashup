using Domain.Common.DTOs;
using Domain.Entities;
namespace Domain.Interfaces;

public interface IJobRepository
{
    public Task<List<JobDto>> GetAllAsync();
}
