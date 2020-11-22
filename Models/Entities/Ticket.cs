using System;
using System.Collections.Generic;

#nullable disable

namespace testAzure
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int BusId { get; set; }
        public int Code { get; set; }
        public int Quantity { get; set; }

        public virtual bus Bus { get; set; }
        public virtual User User { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
