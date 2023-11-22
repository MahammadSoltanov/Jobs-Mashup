using Domain.Common;

namespace Domain.Entities;

public class Job : BaseJob
{
    public Company Company { get; set; }
    public Country Country { get; set; }
}
