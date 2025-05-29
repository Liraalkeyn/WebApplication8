using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class Master
{
    public int MasterId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<RepairPart> RepairParts { get; set; } = new List<RepairPart>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
