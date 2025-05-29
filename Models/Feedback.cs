using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int RequestId { get; set; }

    public string Message { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
