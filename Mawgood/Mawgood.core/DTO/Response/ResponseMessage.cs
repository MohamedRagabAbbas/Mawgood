using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.DTO.Response
{
    public  class ResponseMessage<T>
    {
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public T? Data { get; set; } 
    }
}
