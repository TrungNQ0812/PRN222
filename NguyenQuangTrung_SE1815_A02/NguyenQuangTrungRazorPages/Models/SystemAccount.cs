using System;
using System.Collections.Generic;

namespace NguyenQuangTrungRazorPages.Models;

public partial class SystemAccount
{
    public short AccountId { get; set; }

    public string? AccountName { get; set; }

    public string? AccountEmail { get; set; }

    public int? AccountRole { get; set; }

    public string? AccountPassword { get; set; }

    public string AccountStatus { get; set; } = null!;

    public virtual ICollection<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
}



public class AdminAccountSettings
{
    public string Email { get; set; }
    public string Password { get; set; }
    public short AccountId { get; set; }
    public string AccountName { get; set; }
    public int AccountRole { get; set; }
}
