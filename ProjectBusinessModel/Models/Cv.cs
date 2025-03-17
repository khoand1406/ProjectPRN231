using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class Cv
{
    public int Id { get; set; }

    public int? ApplicantId { get; set; }

    public string CvName { get; set; }

    public string CvUrl { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public bool IsActive { get; set; }

    public virtual Applicant Applicant { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
