using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TicketsCorinthiansCore.Helpers;
using TicketsCorinthiansCore.Models;

namespace TicketsCorinthiansCore.Controllers
{
    [Route("api/[controller]")]
    public class UpdatesController : Controller
    {
        private IHubContext<GridEventsHub> _hubContext;

        public UpdatesController(IHubContext<GridEventsHub> gridEventsHubContext)
        {
            this._hubContext = gridEventsHubContext;
        }

        private bool EventTypeSubscriptionValidation
            => HttpContext.Request.Headers["aeg-event-type"].FirstOrDefault() == "SubscriptionValidation";

        private bool EventTypeNotification
            => HttpContext.Request.Headers["aeg-event-type"].FirstOrDefault() == "Notification";

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var jsonContent = await reader.ReadToEndAsync();

                if (EventTypeSubscriptionValidation)
                {
                    var gridEvent = JsonConvert.DeserializeObject<List<GridEvent<Dictionary<string, string>>>>(jsonContent).First();

                    await this._hubContext.Clients.All.SendAsync(
                        "gridpudate",
                        gridEvent.Id,
                        gridEvent.EventType,
                        gridEvent.Subject,
                        gridEvent.EventTime.ToLongTimeString(),
                        jsonContent.ToString());

                    var validationCode = gridEvent.Data["validationCode"];

                    return new JsonResult(new { validationResponse = validationCode });
                }
                else if (EventTypeNotification)
                {
                    var events = JArray.Parse(jsonContent);
                    foreach (var e in events)
                    {
                        var details = JsonConvert.DeserializeObject<GridEvent<dynamic>>(e.ToString());
                        await this._hubContext.Clients.All.SendAsync(
                            "gridupdate",
                            details.Id,
                            details.EventType,
                            details.Subject,
                            details.EventTime.ToLongTimeString(),
                            e.ToString());
                    }

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

        }
    }
}