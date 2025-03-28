using System;
using System.Collections.Generic;

namespace TrungNQ_Project_PRN222.Models;

public partial class AccountPermission
{
    public int AccountPermissionId { get; set; }

    public int AccountId { get; set; }

    public int PermissionId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Permission Permission { get; set; } = null!;
}
