namespace IrishJobs.Models
{
    public class AdCandidateModel
    {
        public int Id { get; set; }
        
        public int AdId { get; set; }
        public AdModel Ad { get; set; }

        public int CandidateId { get; set; }

        public CandidateModel Candidate { get; set; }
    }
}