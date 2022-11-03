using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrederDate { get; set; }
        public double OrderSum { get; set; }
        public int UserId { get; set; }
    }
}
