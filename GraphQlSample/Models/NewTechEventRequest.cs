using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlSample.Models
{
    public class NewTechEventRequest
    {
        public string EventName { get; set; }
        public string Speaker { get; set; }
        public DateTime EventDate { get; set; }
    }
}
