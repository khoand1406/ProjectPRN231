using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class JobViewed
{
    public int Id { get; set; }

    public int? ApplicantId { get; set; }

    public int? JobId { get; set; }

    public DateTime ViewAt { get; set; }

    public virtual Applicant Applicant { get; set; }

    public virtual Job Job { get; set; }
}
