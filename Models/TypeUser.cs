using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class TypeUser
{
    public int TypeUserId { get; set; }

    public string NameOfType { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
