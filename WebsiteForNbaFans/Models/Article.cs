using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class Article
{
    public int ArticleId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime PublishedDate { get; set; }

    public string? Author { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
