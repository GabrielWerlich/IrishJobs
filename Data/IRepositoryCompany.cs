using IrishJobs.Models;
namespace IrishJobs.Data
{

    public interface IRepositoryCompany

    {
        //General
        Task<int> Create(CompanyModel company);

        Task<int> Update(CompanyModel company);

        Task<int> Delete(int id);

        Task<CompanyModel[]> GetCompany(int id);     

        Task<CompanyModel[]> GetAllCompanies();   
    }
}