using System.Threading.Tasks;
using HttpManager.DataContract;

namespace BandsInTownUWP.IServices
{
    public interface IJustAnnouncedEventsService
    {
        Task<JustAccouncedEventsContract> GetJustAnnouncedEvents();
    }
}
