using Microsoft.EntityFrameworkCore;
using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.Companies
{
    public class CompanyRepository:ICompanyRepository
    {
        private FinalProjectPrn231Context _context;

        public CompanyRepository( FinalProjectPrn231Context context)
        {
            _context = context;
        }

        public void DeleteCompany(int id)
        {
            try
            {
                Company ?company= _context.Companies.Find(id);
                _context.Companies.Remove(company);
                _context.SaveChanges();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Company> GetCompanies()
        {
            try
            {
                var CompanyList= new List<Company>();
                CompanyList= _context.Companies.ToList();
                return CompanyList;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public Company GetCompanyById(int id)
        {
            try
            {
                var company= _context.Companies.FirstOrDefault(x => x.Id == id);
                return company;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public List<Company> getCompanyByLocation(string location)
        {
            try
            {
                var companyList= _context.Companies.Where(com=> com.Address.Contains(location)).ToList();
                return companyList;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public List<Company> getCompanyBySearchNameandLocation(string searchnName, string location)
        {
            try
            {
                var conpanyList= _context.Companies.Where(com=> com.CompanyName.Contains(searchnName) 
                                                        && com.Address.Contains(location))
                                                        .ToList();
                return conpanyList;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public List<Company> getCompanyBySearchnName(string searchnName)
        {
            try
            {
                var companyList = _context.Companies.Where(com => com.CompanyName.Contains(searchnName)).ToList();
                return companyList;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public List<Company> getCompanyByTechStack(string techStack)
        {
            try
            {
                var listCompany= _context.Companies.Where(com=> com.TechStack.Contains(techStack)).ToList();
                return listCompany;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public List<Company> getCompanyPaging(int pagesize, int page)
        {
            try
            {
                var companyList= _context.Companies.Skip(pagesize)
                                         .Take(pagesize)
                                         .ToList();
                return companyList;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public Company getCompanyWithImages(int id)
        {
            try
            {
                var company = new Company();
                company = _context.Companies.Include(com => com.CompanyListImages)
                                            .FirstOrDefault(com => com.Id == id);
                return company;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            
            
        }

        public List<Company> getCompanywithLatestJob()
        {
            try
            {
            var listCompany = _context.Companies
                                      .Where(com => com.Jobs.Any()) // Only consider companies with jobs
                                      .Select(com => new
            {
                Company = com,
                LatestJobDate = com.Jobs.Max(job => job.PostedAt) // Get the latest job posting date for each company
            })
            .OrderByDescending(com => com.LatestJobDate) // Order companies by the latest job posting date
            .Take(5) // Take the top 5 companies
            .Select(com => com.Company) // Select only the company info
            .ToList();

                return listCompany;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public List<Company> GetTopFiveCompanies()
        {
            try
            {
                var listCompany= _context.Companies.Take(5).ToList();
                return listCompany;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public List<Company> getTopFollowCompany()
        {
            try
            {
                var ListCompany = _context.Companies.OrderByDescending(com => com.FollowCount).ToList();
                return ListCompany;
            }catch (Exception ex) {
                Console.WriteLine($"{ex.ToString()}");
                throw;
            }
            
        }


        public void UpdateCompany(int id, Company company)
        {
            try
            {
                Company ?TempC = _context.Companies.FirstOrDefault(com => com.Id == id);
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

       
    }
}
