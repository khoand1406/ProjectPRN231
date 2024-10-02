using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class Applicant
{
    public int Id { get; set; }

    public int? Userid { get; set; }

    public string FullName { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Education { get; set; }

    public string Experience { get; set; }

    public int? CvId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Cv> Cvs { get; set; } = new List<Cv>();

    public virtual ICollection<JobSaved> JobSaveds { get; set; } = new List<JobSaved>();

    public virtual ICollection<JobViewed> JobVieweds { get; set; } = new List<JobViewed>();

    public virtual User User { get; set; }

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
