using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.Application.Abstractions.Security
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        
        public string Issuer { get; set; }
        
        public string SecurityKey { get; set; }
        
        public int Expiration { get; set; }
        
        
    }
}