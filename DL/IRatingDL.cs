using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IRatingDL
    {
        Task insert(Rating rating);
    }
}