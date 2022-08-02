using IrishJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace IrishJobs.Data
{
    public class RepositoryCandidate : IRepositoryCandidate
    {
        private readonly DataContext _context;

        public RepositoryCandidate(DataContext context)
        {
            _context = context;
        }

       public Task<int> Create(CandidateModel candidate)
        {
            candidate.CreationDate = DateTime.Now.Date;
            _context.CandidateModels.Add(candidate);
            return _context.SaveChangesAsync();
        }

        public Task<int> Delete(int id)
        {
             CandidateModel candidate = _context.CandidateModels.FirstOrDefault(a=>a.Id == id);
             _context.CandidateModels.Remove(candidate);
             return _context.SaveChangesAsync();
        }

        public Task<int> Update(CandidateModel candidate)
        {   
            if(candidate.Id == 0)
                return _context.SaveChangesAsync();

            candidate.LastUpdate = DateTime.Now.Date;
             _context.CandidateModels.Update(candidate);   
            return _context.SaveChangesAsync();
        }

        public Task<CandidateModel[]> GetCandidate(int id)
        {
            IQueryable<CandidateModel> query = _context.CandidateModels.Where(c=>c.Id == id);
            return query.ToArrayAsync();
        }

        public Task<CandidateModel[]> GetAllCandidates()
        {
            IQueryable<CandidateModel> query = _context.CandidateModels;
            return query.ToArrayAsync();
        }
    }
}


            