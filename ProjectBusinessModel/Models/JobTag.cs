using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class JobTag
{
    public int Id { get; set; }

    public int? JobId { get; set; }

    public string Tagname { get; set; }

    public virtual Job Job { get; set; }
}
