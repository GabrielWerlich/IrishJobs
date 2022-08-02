namespace IrishJobs.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public Boolean Permanent { get; set; }

        public Boolean Contract { get; set; }

        public DateTime CreationDate { get; set; }

        public IList<AdModel> Ads { get; set; }
        
    }
}