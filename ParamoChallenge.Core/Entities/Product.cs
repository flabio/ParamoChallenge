using System;
using System.Collections.Generic;

namespace ParamoChallenge.Core.Entities;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public int IdArticle { get; set; }

    public byte? IsActive { get; set; }

    public virtual Article? IdArticleNavigation { get; set; }
}
