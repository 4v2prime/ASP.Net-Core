using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstAspCore.Models;

public partial class TblAnimeList
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public double? Rating { get; set; }
    [Required]
    public string? Genre { get; set; }
    [Required]
    public string? Description { get; set; }

    public bool? Isfavourite { get; set; }
    [Required]
    public int Sataus { get; set; }

    public virtual TblStatus SatausNavigation { get; set; } = null!;
}
