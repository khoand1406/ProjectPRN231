using ProjectBusinessModel.Models;

namespace ProjectDataAccess.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly FinalProjectPrn231Context _context;
        public UserRepository(FinalProjectPrn231Context context)
        {
            _context = context;
        }

        public User getUserByUsernameandPassword(string username, string password)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                return user ?? throw new KeyNotFoundException("User not found");
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public User getUserById(int id)
        {
            try
            {
                return _context.Users.FirstOrDefault(u => u.UserId == id) ?? throw new KeyNotFoundException("User not found");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public User getUserByName(string username)
        {
            var user = new User();
            if (_context != null)
            {
                try
                {
                    user = _context.Users.FirstOrDefault(user => user.Username == username);
                    if (user != null)
                    {
                        return user;
                    }
                    else
                    {
                        Console.WriteLine($"Not found user with username is: {username}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return user;
        }
        public void AddNewUser(User user)
        {
            if (_context != null)
            {
                try
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void UpdateApplicantProfile(int id, Applicant applicant)
        {

            if (_context != null)
            {

                User? user = _context.Users.FirstOrDefault(user => user.UserId == id);
                if (user != null)
                {
                    Applicant applicantTemp = new Applicant();
                    applicantTemp.Userid = id;
                    applicantTemp.Address = applicant.Address;
                    applicantTemp.FullName = applicant.FullName;
                    applicantTemp.CvId = applicant.CvId;
                    applicantTemp.Education = applicant.Education;
                    applicantTemp.Phone = applicant.Phone;
                    applicantTemp.Experience = applicant.Experience;

                    _context.Applicants.Add(applicantTemp);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Not find the user with {id} ");

                }
            }
        }
        public void UpdateEmployerProfile(int id, Employer employer)
        {
            if (_context != null)
            {
                User? user = _context.Users.FirstOrDefault(user => user.UserId == id);
                if (user != null)
                {
                    Employer employerTemp = new Employer();
                    employerTemp.Position = employer.Position;
                    employerTemp.CompanyId = employer.CompanyId;
                    employerTemp.Phone = employer.Phone;
                    employerTemp.Email = employer.Email;
                    employerTemp.UserId = id;

                    _context.Employers.Add(employerTemp);
                    _context.SaveChanges();

                }
                else
                {
                    Console.WriteLine($"Can't not find user with id: {id}");
                }

            }
        }

        public void DeleteUser(int id)
        {
            if (_context != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Can't not find user with id= {id} to remove ");
                }
            }
        }

        

           
    }
}
