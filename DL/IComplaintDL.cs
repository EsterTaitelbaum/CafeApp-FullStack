using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IComplaintDL
    {
        Task sendComplaint(Complaints complaint);

    }
}
