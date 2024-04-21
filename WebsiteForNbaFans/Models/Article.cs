using System;
using System.Collections.Generic;

namespace WebsiteForNbaFans.Models;

public partial class Article
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool Homepage { get; set; }

    public string Img { get; set; } = null!;
}
