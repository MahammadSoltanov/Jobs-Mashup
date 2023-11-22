namespace Domain.Common;

public class BaseJob : BaseEntity
{
    public string Position { get; set; }
    public int CompanyId { get; set; }
    public string JobLink { get; set; }
    public DateTime PublishDate { get; set; }
    public int CountryId { get; set; }
}
