using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlSample.Models
{
    public class NewParticipantRequest
    {
        public string ParticipantName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
