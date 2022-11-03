using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime OrederDate { get; set; }
        public double OrderSum { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
