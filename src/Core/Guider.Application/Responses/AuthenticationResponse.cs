using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Responses
{
    public class AuthenticationResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

}
