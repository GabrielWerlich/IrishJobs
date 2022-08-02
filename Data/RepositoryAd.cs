using System.Linq;
using System.Threading.Tasks;
using IrishJobs.Models;
using Microsoft.EntityFrameworkCore;


namespace IrishJobs.Data.Repositories
{
    public class RepositoryAd : IRepositoryAd
    {
        private readonly DataContext _context;

        public RepositoryAd(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Create(AdModel ad)
        {
            ad.CreationDate = DateTime.Now.Date;
            _context.AdModels.Add(ad);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            
             AdModel ad = await _context.AdModels.FirstOrDefaultAsync(a=>a.Id == id);
             _context.AdModels.Remove(ad);
             return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(AdModel UpdatedAd)
        {                
             UpdatedAd.LastUpdate = DateTime.Now.Date;
             _context.AdModels.Update(UpdatedAd);            
            return await _context.SaveChangesAsync();
        }

        public async Task<AdModel[]> GetAsyncAds()
        {
            IQueryable<AdModel> query = _context.AdModels;
            return await query.ToArrayAsync();
        }

        public async Task<AdModel[]> GetAsyncAdsByCompany(int id)
        {
            IQueryable<AdModel> query = _context.AdModels.Where(x=>x.CompanyId == id);
            return await query.ToArrayAsync();
        }

        public Task<int> CandidateSubscribe(int idAd, int IdCandidate)
        {
            var AdCandidate = new AdCandidateModel();
            AdCandidate.AdId = idAd;
            AdCandidate.CandidateId = IdCandidate;
            _context.AdCandidatesModels.Add(AdCandidate);
            return _context.SaveChangesAsync();
        }

        public Task<int> CandidateUnsubscribe(int idAd, int IdCandidate)
        {
            throw new NotImplementedException();
        }
    }
}


            