//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace IrishJobs.Models
{
    public class AdModel
    {

        public int Id { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Salary { get; set; }

        public string Description { get; set; }      

        public Boolean Remote { get; set; }

        public Boolean Permanent { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public int CompanyId { get; set; }

        public CompanyModel Company { get; set; }

        public IList<AdCandidateModel> AdsCandidates { get; set; }
    }
}