using System;
using System.Collections.Generic;

namespace NguyenQuangTrungProject.Models;

public partial class Document
{
    public int DocumentId { get; set; }

    public string DocumentContent { get; set; } = null!;

    public string DocumentTitle { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int DocumentStatusId { get; set; }

    public int AccountId { get; set; }

    public int CategoryId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual DocumentStatus DocumentStatus { get; set; } = null!;
}
