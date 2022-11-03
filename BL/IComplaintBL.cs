using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace BL
{
    public interface IComplaintBL
    {
        Task sendComplaint(Complaints complaint);
    }
}
