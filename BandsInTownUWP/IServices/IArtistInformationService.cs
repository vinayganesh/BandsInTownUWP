using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpManager.DataContract;

namespace BandsInTownUWP.IServices
{
    public interface IArtistInformationService
    {
        Task<ArtistContract> GetArtistInfo(string artistName);

        Task<List<EventsContract>> GetArtistEvents(string artistName);

        Task<List<EventsBasdOnRadiusContract>> GetAristEventBasedOnDistanceFromLocation(string artistName, string distance);
    }
}
