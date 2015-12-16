using System.Threading.Tasks;
using HttpManager.DataContract;

namespace BandsInTownUWP.IServices
{
    public interface IRecommendedArtists
    {
        Task<RecommendedArtistsContract> GetRecommendedArtists();
    }
}
