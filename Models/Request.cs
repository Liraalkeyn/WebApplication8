using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public DateOnly StartDate { get; set; }

    public int TechTypeId { get; set; }

    public string ClimateTechModel { get; set; } = null!;

    public string ProblemDescryption { get; set; } = null!;

    public int? RequestStatusId { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public int? RepairPartsId { get; set; }

    public int? MasterId { get; set; }

    public int ClientId { get; set; }

    public virtual Client? Client { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Master? Master { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual RepairPart? RepairParts { get; set; }

    public virtual RequestStatus? RequestStatus { get; set; }

    public virtual TechType? TechType { get; set; } = null!;
}
