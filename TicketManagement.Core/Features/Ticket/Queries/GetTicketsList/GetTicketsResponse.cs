﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Enums;

namespace TicketManagement.Core.Features.Ticket.Queries.GetTicketsList
{
    public class GetTicketsResponse
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Status { get; set; }
        public string Color { get; set; } 

    }
}
