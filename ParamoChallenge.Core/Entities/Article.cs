using System;
using System.Collections.Generic;

namespace ParamoChallenge.Core.Entities;

public partial class Article
{
    public int IdArticle { get; set; }

    public string? Name { get; set; }

    public byte? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
