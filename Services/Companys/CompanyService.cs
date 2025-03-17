using FluentValidation;
using FluentValidation.Validators;
using ProjectBusinessModel.Models;
using ProjectDataAccess.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions.ValidationException;

namespace Services.Companys
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IValidator<Company> _validator;

        public CompanyService(ICompanyRepository companyRepository, IValidator<Company> validator)
        {
            _companyRepository = companyRepository;
            _validator = validator;
        }

        public void DeleteCompany(int id)
        {
            var company = _companyRepository.GetCompanyById(id);
            if (company == null)
                throw new ArgumentException("Company not found.");

            _companyRepository.DeleteCompany(id);
        }

        public List<Company> GetCompanies()
        {
            return _companyRepository.GetCompanies().ToList();
        }

        public Company GetCompanyById(int id)
        {
            var company = _companyRepository.GetCompanyById(id);
            if (company == null)
                throw new ArgumentException("Company not found.");

            return company;
        }

        
        public List<Company> GetTopFiveCompanies()
        {
            return _companyRepository.GetTopFiveCompanies().ToList();
        }

        

        public void UpdateCompany(int id, Company company)
        {
            var existingCompany = _companyRepository.GetCompanyById(id);
            if (existingCompany == null)
                throw new ArgumentException("Company not found.");

            var validationResult= _validator.Validate(company);
            if (!validationResult.IsValid)
            {
                throw new CompanyValidationException();
            }
            else
            {
                existingCompany.CompanyName = company.CompanyName;
                existingCompany.Address = company.Address;
                existingCompany.TechStack = company.TechStack;


                _companyRepository.UpdateCompany(id, existingCompany);
            }

           
        }

        public List<Company> getTopFollowCompany()
        {
            return _companyRepository.getTopFollowCompany().ToList();
        }

        public Company getCompanyWithImages(int id)
        {
            return _companyRepository.getCompanyWithImages(id);
        }

        public List<Company> getCompanyPaging(int pagesize, int page)
        {
            return _companyRepository.getCompanyPaging(pagesize, page).ToList();
        }

        public List<Company> getCompanyBySearchnName(string searchnName)
        {
            return _companyRepository.getCompanyBySearchnName(searchnName).ToList();
        }

        public List<Company> getCompanyBySearchNameandLocation(string searchnName, string location)
        {
            return _companyRepository.getCompanyBySearchNameandLocation(searchnName, location).ToList();
        }

        public List<Company> getCompanywithLatestJob()
        {
            return _companyRepository.getCompanywithLatestJob().ToList();
        }

        public List<Company> getCompanyByTechStack(string techStack)
        {
            return _companyRepository.getCompanyByTechStack(techStack).ToList();
        }
         
        public List<Company> getCompanyByLocation(string location)
        {
            return _companyRepository.getCompanyByLocation(location).ToList();
        }
    }
}
