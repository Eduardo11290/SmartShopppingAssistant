using System;
using System.Collections.Generic;
using System.Text;

namespace SmartShoppingAssistant.BusinessLogic.DTOs
{
    public class AuthResponseDTO
    {
        public string Token { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
