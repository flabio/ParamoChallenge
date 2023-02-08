using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoChallenge.Core.DTOs
{
    public class ArticleDto
    {
        public int IdArticle { get; set; }

        public string? Name { get; set; }

        public byte? IsActive { get; set; }
    }
}
