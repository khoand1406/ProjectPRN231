using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public string Salary { get; set; }

    public string JobType { get; set; }

    public string Requirements { get; set; }

    public DateTime PostedAt { get; set; }

    public DateTime ExpiredAt { get; set; }

    public int? CompanyId { get; set; }

    public bool? Status { get; set; }

    public string EmploymentType { get; set; }

    public string Benefits { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Company Company { get; set; }

    public virtual ICollection<JobSaved> JobSaveds { get; set; } = new List<JobSaved>();

    public virtual ICollection<JobTag> JobTags { get; set; } = new List<JobTag>();

    public virtual ICollection<JobViewed> JobVieweds { get; set; } = new List<JobViewed>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
