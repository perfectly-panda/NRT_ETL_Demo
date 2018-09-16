using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRChat.Hubs;
using System;
using System.Linq;
using System.Net.Http;

namespace NRTDemoWeb.Controllers
{

    [ApiController]
    [Produces("application/json")]
    public class EventGridEventHandlerController : Controller
    {
        private readonly IHubContext<TruckHub> _hubContext;

        public EventGridEventHandlerController(IHubContext<TruckHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("api/EventGridEventHandler")]
        public IActionResult Post([FromBody]object request)
        {
            //Deserializing the request 
            EventGridSubscriber eventGridSubscriber = new EventGridSubscriber();

            EventGridEvent[] eventGridEvents = eventGridSubscriber.DeserializeEventGridEvents(request.ToString());


            foreach (EventGridEvent eventGridEvent in eventGridEvents)
            {
                // Validate whether EventType is of "Microsoft.EventGrid.SubscriptionValidationEvent"
                if (eventGridEvent.EventType == "Microsoft.EventGrid.SubscriptionValidationEvent")
                {
                    var eventData = (SubscriptionValidationEventData)eventGridEvent.Data;
                    // Do any additional validation (as required) such as validating that the Azure resource ID of the topic matches
                    // the expected topic and then return back the below response
                    var responseData = new SubscriptionValidationResponse()
                    {
                        ValidationResponse = eventData.ValidationCode
                    };


                    if (responseData.ValidationResponse != null)
                    {

                        return Ok(responseData);
                    }
                }
                else
                {
                    var truck = JsonConvert.DeserializeObject<Truck>(eventGridEvent.Data.ToString());

                    object[] args = { truck.TruckId, truck };

                    _hubContext.Clients.All.SendCoreAsync("SendMessage", args);

                    Console.WriteLine(truck);
                }
            }
        
            return Ok();
        }
    }
}