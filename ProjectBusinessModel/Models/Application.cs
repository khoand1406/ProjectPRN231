using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class Application
{
    public int Id { get; set; }

    public int? ApplicantId { get; set; }

    public int? JobId { get; set; }

    public int? CvId { get; set; }

    public string CoverLetter { get; set; }

    public string Status { get; set; }

    public DateTime AppliedAt { get; set; }

    public virtual Applicant Applicant { get; set; }

    public virtual Cv Cv { get; set; }

    public virtual Job Job { get; set; }
}
