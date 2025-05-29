using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class TechType
{
    public int TechTypeId { get; set; }

    public string ClimateTechType { get; set; } = null!;

    public virtual ICollection<RepairPart> RepairParts { get; set; } = new List<RepairPart>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
