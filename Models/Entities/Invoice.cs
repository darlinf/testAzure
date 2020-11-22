using System;
using System.Collections.Generic;

#nullable disable

namespace testAzure
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
