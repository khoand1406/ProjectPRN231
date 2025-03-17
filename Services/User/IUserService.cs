using Microsoft.AspNetCore.Identity;
using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    internal interface IUserService
    {
        public ProjectBusinessModel.Models.User getAuthenticated(string username, string password);

        public bool isAdmin(ProjectBusinessModel.Models.User user);

        public bool isEmployer(ProjectBusinessModel.Models.User user);

        public bool isEmployee(ProjectBusinessModel.Models.User user);

        public ProjectBusinessModel.Models.User getUserById(int id);

        public ProjectBusinessModel.Models.User getUserByName(string username);

        public void AddNewUser(ProjectBusinessModel.Models.User user);

        public void UpdateApplicantProfile(int id, Applicant applicant);

        public void UpdateEmployerProfile(int id, Employer employer);


    }
}
