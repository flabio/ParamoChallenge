using ParamoChallenge.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoChallenge.Core.Responses
{
    public class ResponseModel : IResponseModal
    {
        public ResponseModel()
        {
            this.IsSuccessfull = false;
            this.Data = null;
        }

        public bool IsSuccessfull { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
