using IrishJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace IrishJobs.Data
{
    public class RepositoryCompany : IRepositoryCompany
    {
        private readonly DataContext _context;

        public RepositoryCompany(DataContext context)
        {
            _context = context;
        }

        public Task<int> Create(CompanyModel company)
        {
            company.CreationDate = DateTime.Now.Date;
            _context.CompanyModels.Add(company);
            return _context.SaveChangesAsync();
        }

        public Task<int> Delete(int id)
        {
             CompanyModel company = _context.CompanyModels.FirstOrDefault(a=>a.Id == id);
             _context.CompanyModels.Remove(company);
             return _context.SaveChangesAsync();
        }

        public Task<int> Update(CompanyModel company)
        {   
            if(company.Id == 0)
                return _context.SaveChangesAsync();

             _context.CompanyModels.Update(company);   
            return _context.SaveChangesAsync();
        }

        public Task<CompanyModel[]> GetCompany(int id)
        {
            IQueryable<CompanyModel> query = _context.CompanyModels.Where(c=>c.Id == id);
            return query.ToArrayAsync();
        }

        public Task<CompanyModel[]> GetAllCompanies()
        {
            IQueryable<CompanyModel> query = _context.CompanyModels;
            return query.ToArrayAsync();
        }

    }
}


            