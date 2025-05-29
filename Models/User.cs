using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int TypeUserId { get; set; }

    public string Phone { get; set; } = null!;

    public virtual TypeUser TypeUser { get; set; } = null!;
}
