using Domain.Common;

namespace Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
