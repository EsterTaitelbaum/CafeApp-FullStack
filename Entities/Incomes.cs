using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Incomes
    {
        public short? ClientCode { get; set; }
        public DateTime? DateT { get; set; }
        public TimeSpan? TimeT { get; set; }
        public short? T1 { get; set; }
        public string Ip { get; set; }
        public DateTime? RecordDate { get; set; }
    }
}
