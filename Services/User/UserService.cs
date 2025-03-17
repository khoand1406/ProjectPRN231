using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ProjectBusinessModel.Models;
using ProjectDataAccess.Users;
using Services.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.CustomValidation;
using Utils.Exceptions;

namespace Services.User
{
    public class UserService : IUserService
    {
        private IUserRepository Repository;
        private IValidator<ProjectBusinessModel.Models.User> validator;
        private IValidator<Applicant> ApplicantValidator;
        private IValidator<Employer> EmployerValidator;
        private readonly IPasswordHasher<ProjectBusinessModel.Models.User> passwordHasher;



        public UserService(IUserRepository repo, IValidator<ProjectBusinessModel.Models.User> validationRules, 
            IValidator<Applicant> ApplicantValidationRules, IValidator<Employer> EmployerValidation, 
            IPasswordHasher<ProjectBusinessModel.Models.User> passwordHasher)
        {
            this.Repository = repo;
            this.validator = validationRules;
            this.ApplicantValidator = ApplicantValidationRules;
            this.EmployerValidator = EmployerValidation;
            this.passwordHasher = passwordHasher;
            
        }

        public void AddNewUser(ProjectBusinessModel.Models.User user)
        {
            var validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                }
                throw new ValidationException(validationResult.Errors);
            }
            else
            {
                user.Password = passwordHasher.HashPassword(user, user.Password);
                Repository.AddNewUser(user);
                
            }

        }

        public ProjectBusinessModel.Models.User getAuthenticated(string username, string password)
        {
            try
            {
                // Fetch the user from the repository based on the username
                var user = Repository.getUserByUsernameandPassword(username, password);
                var id = 0;
                if (user == null)
                {
                    // User does not exist
                    throw  new EntityNotFoundException("User not found.", id);
                }

                // Verify the password (assuming the password is hashed and stored securely)
                if (!VerifyPassword(password, user.Password))
                {
                    // Password does not match
                    throw new Exception("Invalid username or password.");
                }

                // If both checks pass, return the authenticated user
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Authentication failed: {ex.Message}");
                throw; // You can also throw a custom exception or return null based on your needs
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            var verificationResult = passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return verificationResult == PasswordVerificationResult.Success;
        }

        public ProjectBusinessModel.Models.User getUserById(int id)
        {
            return Repository.getUserById(id);
        }

        public ProjectBusinessModel.Models.User getUserByName(string username)
        {
            return Repository.getUserByName(username);
        }

        public bool isAdmin(ProjectBusinessModel.Models.User user)
        {
            var validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                }
                throw new ValidationException(validationResult.Errors);
            }
            else
            {
                return user.Role.Equals("Admin");
            }
        }

        public bool isEmployee(ProjectBusinessModel.Models.User user)
        {
            var validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                }
                throw new ValidationException(validationResult.Errors);
            }
            else
            {
                return user.Role.Equals("Employee");
            }
        }

        public bool isEmployer(ProjectBusinessModel.Models.User user)
        {
            var validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                }
                throw new ValidationException(validationResult.Errors);
            }
            else
            {
                return user.Role.Equals("Employeer");
            }
        }

        public void UpdateApplicantProfile(int id, Applicant applicant)
        {
            var currentApplicant= Repository.getUserById(id);
            if (currentApplicant != null)
            {
                var validationResult = ApplicantValidator.Validate(applicant);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                    }
                    throw new ValidationException(validationResult.Errors);
                }
                else
                {
                    Repository.UpdateApplicantProfile(id, applicant);
                }
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }

        public void UpdateEmployerProfile(int id, Employer employer)
        {
            var currentEmployer = Repository.getUserById(id);
            if (currentEmployer != null)
            {
                var validationResult = EmployerValidator.Validate(employer);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
                    }
                    throw new ValidationException(validationResult.Errors);
                }
                else
                {
                    Repository.UpdateEmployerProfile(id, employer);
                }
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }
    }
}
