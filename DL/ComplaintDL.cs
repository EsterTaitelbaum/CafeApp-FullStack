using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ComplaintDL: IComplaintDL
    {
        CoffeeShopContext _CoffeeShopContext;
        public ComplaintDL(CoffeeShopContext CoffeeShopContext)
        {
            _CoffeeShopContext = CoffeeShopContext;

        }

        public async Task sendComplaint(Complaints complaint)
        {
            await _CoffeeShopContext.Complaints.AddAsync(complaint);
            await _CoffeeShopContext.SaveChangesAsync();
        }

    }
}
