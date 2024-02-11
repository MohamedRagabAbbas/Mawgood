using Mawgood.Core.IResponses.IResponseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.EF.Responses.ResponseMessage
{
    public class ResponseMessage<T>: IResponseMessage<T> 
    {
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public T? Data { get; set; }

    }
}
