using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerNet
{
    public class Response
    {

        public bool Success;
        public string Message;

        public Response()
        {
            Success = true;
            Message = "";
        }

        public void Fail(Exception ex)
        {
            Success = false;
            Message = ex.ToString();
        }
    }
}
