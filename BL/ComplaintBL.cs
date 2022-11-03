using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    public class ComplaintBL : IComplaintBL
    {
        IComplaintDL complaintDL;

        public ComplaintBL(IComplaintDL complaintDl)
        {
            this.complaintDL = complaintDl;
        }

       

        public async Task sendComplaint(Complaints complaint)
        {
            await complaintDL.sendComplaint(complaint);
        }

        
    }
}
