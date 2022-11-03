using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Complaints
    {
        public string ClientCode { get; set; }
        public int SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string ComplaintDesc { get; set; }
        public string UpdateDate { get; set; }
        public string LetterDesc { get; set; }
        public string Summary { get; set; }
        public int Id { get; set; }
    }
}
