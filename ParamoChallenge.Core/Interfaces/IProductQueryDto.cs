using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoChallenge.Core.Interfaces
{
    public interface IProductQueryDto
    {
        public int IdProduct { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? Date { get; set; }

        public int? IdArticle { get; set; }

        public byte? IsActive { get; set; }

        public string ArticleName { get; set; }

    }
}
