using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApi.Models
{
    public class ResponseData
    {
        public int Code { get; set; } = 200;
        public object Data { get; set; }
        public string ErrorMessage { get; set; }

    }
}
