using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    public interface IHelix<T>
    {
        Task<IEnumerable<string>> GetAllFromHelixAsync();
    }
}
