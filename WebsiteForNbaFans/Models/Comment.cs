using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime PublishedDate { get; set; }

    public int? UserId { get; set; }

    public int? ArticleId { get; set; }

    public virtual Article? Article { get; set; }

    public virtual User? User { get; set; }
}
