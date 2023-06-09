using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace E_Ticaret.Application.Features.Commands.AuthCommands.GoogleLogin
{
    public partial class GoogleLoginCommandRequest : IRequest<GoogleLoginCommandResponse>
    {
        public string Id { get; set; }
        
        public string IdToken { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        
        public string Provider { get; set; }
            
    }
}
