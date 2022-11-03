using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RatingBL : IRatingBL
    {
        IRatingDL _ratingDL;

        public RatingBL(IRatingDL ratingDL)
        {
            _ratingDL = ratingDL;
        }

        public async Task insert(Rating rating)
        {
            await _ratingDL.insert(rating);
        }

    }
}
