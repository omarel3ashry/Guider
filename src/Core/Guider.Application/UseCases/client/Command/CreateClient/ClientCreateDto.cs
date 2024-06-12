using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Command.CreateClient
{
    public class ClientCreateDto
    {
        public int Id { get; set; }
       
        public int UserId { get; set; }
       
        // Additional properties from User
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string BankAccount { get; set; }
    }
}
