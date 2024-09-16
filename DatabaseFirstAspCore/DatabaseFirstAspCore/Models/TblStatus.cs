using System;
using System.Collections.Generic;

namespace DatabaseFirstAspCore.Models;

public partial class TblStatus
{
    public int Sid { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<TblAnimeList> TblAnimeLists { get; set; } = new List<TblAnimeList>();
}
