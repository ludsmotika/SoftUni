using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;
using Homies.Models.Type;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;

namespace Homies.Services
{
    public class EventService : IEventService
    {

        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task AddEventAsync(EventFormViewModel model, string organizerId)
        {

            Event eventToAdd = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganizerId = organizerId,
                CreatedOn = DateTime.Now
            };

            await context.Events.AddAsync(eventToAdd);
            await context.SaveChangesAsync();
        }

        public async Task<bool> AddUserToEvent(int id, string userId)
        {
            //create EventParticipant and add it to the context
            var eventParticipant = await context.EventsParticipants.FirstOrDefaultAsync(x=>x.EventId==id && x.HelperId==userId);

            if (eventParticipant == null)
            {
                EventParticipant addedParticipantEvent = new EventParticipant()
                {
                    HelperId = userId,
                    EventId = id
                };

                await context.EventsParticipants.AddAsync(addedParticipantEvent);
                await context.SaveChangesAsync();

                return false;
            }

            return true;
        }

        public async Task EditEventById(int id, EventFormViewModel formModel)
        {
            //get the event and change the values
            var eventToEdit = await context.Events.FirstAsync(x => x.Id == id);

            eventToEdit.Name= formModel.Name;
            eventToEdit.Description= formModel.Description;
            eventToEdit.Start= formModel.Start;
            eventToEdit.End= formModel.End;
            eventToEdit.TypeId= formModel.TypeId;

            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<AllEventsViewModel>> GetAllEventsAsync()
        {
            //get all the events and return them to the controller

            var eventsModel = await context.Events.Select(x => new AllEventsViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type.Name,
                Start = x.Start,
                Organiser = x.Organizer.UserName
            }).ToListAsync();

            return eventsModel;
        }

        public async Task<EventFormViewModel> GetEventByIdAsync(int id)
        {
            var eventModel = await context.Events.FirstAsync(x => x.Id == id);

            EventFormViewModel modelToEdit = new EventFormViewModel() 
            {
              Name = eventModel.Name,
              Description = eventModel.Description,
              Start = eventModel.Start,
              End = eventModel.End,
              TypeId = eventModel.TypeId
            };

            return modelToEdit;
        }

        public async Task<EventDetailsViewModel> GetEventDetailsByIdAsync(int id)
        {
            var eventModel = await context.Events.FirstAsync(x => x.Id == id);

            EventDetailsViewModel detailsModel = new EventDetailsViewModel()
            {
                Id= eventModel.Id,
                Name = eventModel.Name,
                Description = eventModel.Description,
                Start = eventModel.Start,
                End = eventModel.End,
                Type = eventModel.Type.Name,
                CreatedOn = eventModel.CreatedOn,
                Organiser = eventModel.Organizer.UserName
            };

            return detailsModel;
        }

        public async Task<IEnumerable<JoinedEventsViewModel>> GetJoinedEventsAsync(string id)
        {
            var joinedEventsModel = await context.EventsParticipants.Where(x => x.HelperId == id).Select(x => new JoinedEventsViewModel()
            {
                Id = x.Event.Id,
                Name = x.Event.Name,
                Type = x.Event.Type.Name,
                Start = x.Event.Start,
                Organiser = x.Event.Organizer.UserName
            }).ToListAsync();

            return joinedEventsModel;
        }

        public async Task<IEnumerable<TypeViewModel>> GetTypes()
        {
            var typesModel = await context.Types.Select(x => new TypeViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return typesModel;
        }

        public async Task RemoveUserFromEvent(int id, string userId)
        {
            //get the row from the context and remove it

            EventParticipant eventParticipant = await context.EventsParticipants.FirstAsync(x=>x.EventId==id && x.HelperId==userId);

            context.EventsParticipants.Remove(eventParticipant);
            await context.SaveChangesAsync();
        }
    }
}
