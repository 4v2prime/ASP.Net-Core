using System;
using System.Collections.Generic;

namespace DatabaseFirstAspCore.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public string? Contact { get; set; }

    public string? Address { get; set; }
}
