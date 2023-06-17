using Homies.Contracts;
using Homies.Models.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using System.Xml.Linq;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {

        private readonly IEventService eventService;
        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }
        public async Task<IActionResult> All()
        {
            //get all the events from the service and pass them to the view

            var allEventsModel = await eventService.GetAllEventsAsync();

            return View(allEventsModel);
        }

        public async Task<IActionResult> Joined()
        {
            //get my events from the service and pass them to the view

            var myEventsModel = await eventService.GetJoinedEventsAsync(GetUserId());

            return View(myEventsModel);
        }

        public async Task<IActionResult> Join(int id) 
        {
            //create eventParticipant from the service with the id of the event and the id of the user

            string userId = GetUserId();

            var alreadyJoined = await eventService.AddUserToEvent(id , userId);

            if (alreadyJoined) 
            {
                return RedirectToAction("All", "Event");
            }

            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Leave(int id) 
        {
            string userId = GetUserId();

            await eventService.RemoveUserFromEvent(id, userId);

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var eventModel = new EventFormViewModel()
            {
                Types = await eventService.GetTypes()
            };

            return View(eventModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            string organizerId = GetUserId();

            await eventService.AddEventAsync(model, organizerId);

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //get the event with the given id and pass it to the Edit View
            var eventModel = await eventService.GetEventByIdAsync(id);

            eventModel.Types = await eventService.GetTypes();

            return View(eventModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormViewModel formModel)
        {
            //pass the id to the model which you have to edit and the model with the new data

            if (ModelState.IsValid == false)
            {
                return View(formModel);
            }

            await eventService.EditEventById(id, formModel);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Details(int id) 
        {
            //get the event and pass it to the view
            EventDetailsViewModel eventDetails = await eventService.GetEventDetailsByIdAsync(id);

            return View(eventDetails);
        }

        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
