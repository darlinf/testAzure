using System;
using System.Collections.Generic;

#nullable disable

namespace testAzure
{
    public partial class bus
    {
        public bus()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
