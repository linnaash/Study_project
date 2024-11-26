using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace lab1_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private static List<string> Events = new()
        {
            "Art Exhibition",
            "Music Concert",
            "Theater Performance",
            "Film Festival",
            "Dance Workshop",
            "Literary Reading",
            "Cultural Fair",
            "Photography Exhibit",
            "Jazz Night",
            "Holiday Gala"
        };


        private readonly ILogger<EventsController> _logger;

       public EventsController(ILogger<EventsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEvents")]
        public IActionResult GetAllEvents(int? sortStrategy)
        {
            if (sortStrategy == 1)
            {
                Events.Sort();
                return Ok(Events);
            }
            else if (sortStrategy == -1)
            {
                Events.Reverse();
                return Ok(Events);
            }
            else if (sortStrategy == null)
            {
                return Ok(Events);
            }
            else
            {
                return BadRequest("Некорректное значение параметра sortStrategy");
            }
        }

        [HttpPost]
        public IActionResult AddEvent(string eventInfo)
        {
            Events.Add(eventInfo);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult UpdateEvent(int index, string eventInfo)
        {
            if (index < 0 || index >= Events.Count)
            {
                return BadRequest("Неверный индекс!!");
            }
            Events[index] = eventInfo;
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEvent(int index)
        {
            if (index < 0 || index >= Events.Count)
            {
                return BadRequest("Неверный индекс!!");
            }
            Events.RemoveAt(index);
            return Ok();
        }
        [HttpGet("{index}")]
        public IActionResult GetEvent(int index)
        {
            if (index < 0 || index >= Events.Count)
            {
                return BadRequest("Неверный индекс!!");
            }
            return Ok(Events[index]);
        }
        [HttpGet("find-by-name")]
        public IActionResult FindEventByName(string name)
        {

            int count = Events.Count(e => e.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (count > 0)
            {
                return Ok(count);
            }
            else
            {
                return BadRequest("Нет такого названия!!");
            }
        }
        

    }
    
}
