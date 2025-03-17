using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.Companies
{
    public interface ICompanyRepository
    {
        List<Company> GetCompanies();

        List<Company> GetTopFiveCompanies();

        Company GetCompanyById(int id);

        List<Company> getTopFollowCompany();

        Company getCompanyWithImages(int id);

        List<Company> getCompanyPaging(int pagesize, int page);

        List<Company> getCompanyBySearchnName(string searchnName);

        List<Company> getCompanyBySearchNameandLocation(string searchnName, string location);

        List<Company> getCompanywithLatestJob();

        List<Company> getCompanyByTechStack(string techStack);

        List<Company> getCompanyByLocation(string location);


        //AdminRole
        void UpdateCompany(int id, Company company);

        void DeleteCompany(int id);



    }
}
