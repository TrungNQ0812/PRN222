using System;
using System.Collections.Generic;

namespace TrungNQ_Project_PRN222.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public string? PhoneNumber { get; set; }

    public int AccountStatus { get; set; }

    public string Email { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<AccountPermission> AccountPermissions { get; set; } = new List<AccountPermission>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
