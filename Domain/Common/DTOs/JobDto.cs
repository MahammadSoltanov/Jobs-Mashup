namespace Domain.Common.DTOs;

public class JobDto
{
    public int Id { get; set; }
    public string Position { get; set; }
    public string CompanyName{ get; set; }
    public string JobLink { get; set; }
    public DateTime PublishDate { get; set; }
    public string CountryName{ get; set; }
}
