using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoChallenge.Core.DTOs
{
    public class ProductDto
    {
        public int IdProduct { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public int? IdArticle { get; set; }

        public byte? IsActive { get; set; }
    }
}
