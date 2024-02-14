using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.DTO.Response
{
    public class AuthenticationResponse
    {
        public int Id { get; set; } = 0;
        public string Role { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
