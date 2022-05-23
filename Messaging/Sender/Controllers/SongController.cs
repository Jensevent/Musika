using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace Sender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;

        public SongController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }



        [HttpPost]
        public async Task<ActionResult> Create(Song song)
        {
            await publishEndpoint.Publish<Song>(song);

            return Ok();
        }
    }
}