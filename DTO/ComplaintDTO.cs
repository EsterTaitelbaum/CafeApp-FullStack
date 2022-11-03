using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ComplaintDTO
    {
        public string Column1 { get; set; }
        public string ClientCode { get; set; }
        public short SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string ComplaintDesc { get; set; }
        public string UpdateDate { get; set; }
        public string LetterDesc { get; set; }
        public string Summary { get; set; }
    }
}
