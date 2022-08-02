using IrishJobs.Models;
namespace IrishJobs.Data
{
    public interface IRepositoryCandidate

    {
        //General
        Task<int> Create(CandidateModel company);

        Task<int> Update(CandidateModel company);

        Task<int> Delete(int id);

        Task<CandidateModel[]> GetCandidate(int id);     

        Task<CandidateModel[]> GetAllCandidates();   
    }
}