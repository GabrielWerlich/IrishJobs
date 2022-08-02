using IrishJobs.Models;

namespace IrishJobs.Data
{

    public interface IRepositoryAd

    {
        //General
        Task<int> Create(AdModel ad);

        Task<int> Update(AdModel ad);

        Task<int> Delete(int id);

        Task<AdModel[]> GetAsyncAds();     

        Task<AdModel[]> GetAsyncAdsByCompany(int id);   

        Task<int> CandidateSubscribe(int idAd, int IdCandidate);

        Task<int> CandidateUnsubscribe(int idAd, int IdCandidate);
    }
}