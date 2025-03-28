using System;
using System.Collections.Generic;

namespace TrungNQ_Project_PRN222.Models;

public partial class Permission
{
    public int PermissionId { get; set; }

    public string PermissionName { get; set; } = null!;

    public virtual ICollection<AccountPermission> AccountPermissions { get; set; } = new List<AccountPermission>();
}
