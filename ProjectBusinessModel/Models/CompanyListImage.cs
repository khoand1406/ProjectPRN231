using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class CompanyListImage
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }

    public string ImageSouce { get; set; }

    public virtual Company Company { get; set; }
}
