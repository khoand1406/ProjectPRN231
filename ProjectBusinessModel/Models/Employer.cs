using System;
using System.Collections.Generic;

namespace ProjectBusinessModel.Models;

public partial class Employer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? CompanyId { get; set; }

    public string Position { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public virtual Company Company { get; set; }

    public virtual User User { get; set; }
}
