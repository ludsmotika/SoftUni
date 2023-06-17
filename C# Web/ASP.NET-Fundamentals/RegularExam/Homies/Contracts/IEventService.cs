using Homies.Models.Event;
using Homies.Models.Type;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventsViewModel>> GetAllEventsAsync();
        Task<IEnumerable<JoinedEventsViewModel>> GetJoinedEventsAsync(string id);
        Task<IEnumerable<TypeViewModel>> GetTypes();
        Task AddEventAsync(EventFormViewModel model, string organizerId);
        Task<EventFormViewModel> GetEventByIdAsync(int id);
        Task<EventDetailsViewModel> GetEventDetailsByIdAsync(int id);
        Task EditEventById(int id, EventFormViewModel formModel);
        Task<bool> AddUserToEvent(int id, string userId);
        Task RemoveUserFromEvent(int id, string userId);
    }
}
