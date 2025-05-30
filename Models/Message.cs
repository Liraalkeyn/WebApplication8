using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public string Text { get; set; } = null!;

    public int MasterId { get; set; }

    public int RequestId { get; set; }

    public virtual Master? Master { get; set; } = null!;

    public virtual Request? Request { get; set; } = null!;
}
