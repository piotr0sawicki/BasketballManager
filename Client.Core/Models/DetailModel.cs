using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Models
{
    public class DetailModel
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeamName { get; set; }
        public int Assists { get; set; }
        public int Details3PA { get; set; }
        public int Details3PM { get; set; }
        public int DetailsFGM { get; set; }
        public int DetailsFGA { get; set; }
    }
}
