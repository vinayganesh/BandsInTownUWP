using System.Threading.Tasks;
using HttpManager.DataContract;

namespace BandsInTownUWP.IServices
{
    public interface IPopularEventsNearbyService
    {
        Task<PopularEventsContract> GetPopularEventsNearby();
    }
}
