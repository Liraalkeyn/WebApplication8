using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class RepairPart
{
    public int RepairPartId { get; set; }

    public int MasterId { get; set; }

    public int TechTypeId { get; set; }

    public string Repair { get; set; } = null!;

    public virtual Master Master { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual TechType TechType { get; set; } = null!;
}
