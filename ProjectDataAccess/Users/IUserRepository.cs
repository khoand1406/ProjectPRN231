using ProjectBusinessModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccess.Users
{
    internal interface IUserRepository
    {
        public User getUserByUsernameandPassword(string username, string password);
        public User getUserById(int id);

        public User getUserByName(string username);

        public void AddNewUser(User user);

        public void UpdateApplicantProfile(int id, Applicant applicant);

        public void UpdateEmployerProfile(int id, Employer employer);

        //Admin
        public void DeleteUser(int id);

        //Manage CV
        

        

    }
}
