using app_agv_molis.Models;
using System.Threading.Tasks;

namespace app_agv_molis.Services
{
    public interface IUser<T>
    {
        Task LoginAsync(UserLogin userLogin);
    }
}
