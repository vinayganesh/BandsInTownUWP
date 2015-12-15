using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandsInTownUWP.Services;
using HttpManager.DataContract;

namespace BandsInTownUWP.IServices
{
    public interface IRecommendedArtists
    {
        Task<RecommendedArtistsContract> GetRecommendedArtists();
    }
}
