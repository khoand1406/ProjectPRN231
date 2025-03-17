using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class Company
{
    public int Id { get; set; }

    public string CompanyName { get; set; }

    public string CompanyLogo { get; set; }

    public string CompanyEmail { get; set; }

    public string Website { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Description { get; set; }

    public int EmployeeSize { get; set; }

    public string TechStack { get; set; }

    public int? FollowCount { get; set; }

    public virtual ICollection<CompanyListImage> CompanyListImages { get; set; } = new List<CompanyListImage>();

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
