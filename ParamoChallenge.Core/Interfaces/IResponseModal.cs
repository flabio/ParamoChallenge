using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoChallenge.Core.Interfaces
{
    public interface IResponseModal
    {
            bool IsSuccessfull { get; set; }

            string Message { get; set; }

            object Data { get; set; }
        }
    
}
