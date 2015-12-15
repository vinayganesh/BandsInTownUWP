using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpManager.DataContract;

namespace BandsInTownUWP.IServices
{
    public interface IPopularEventsNearbyService
    {
        Task<PopularEventsContract> GetPopularEventsNearby();
    }
}
