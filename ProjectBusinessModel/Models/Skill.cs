using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
