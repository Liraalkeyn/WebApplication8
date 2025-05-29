using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class RequestStatus
{
    public int RequestStatusId { get; set; }

    public string Message { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
