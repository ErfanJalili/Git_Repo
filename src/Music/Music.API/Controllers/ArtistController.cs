using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Application.CQRS.Artist.Command;
using Music.Application.CQRS.Artist.Query;
using Music.Application.CQRS.Artist.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Music.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MusicController> _logger;

        public ArtistController(IMediator mediator, ILogger<MusicController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetArtistById/{id}")]
        [ProducesResponseType(typeof(IEnumerable<ArtistResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ArtistResponse>>> GetMusicById(int id)
        {
            var query = new GetArtistByIdQuery(id);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("GetAllArtists")]
        [ProducesResponseType(typeof(IEnumerable<ArtistResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ArtistResponse>>> GetAllArtist()
        {
            var query = new GetAllArtistQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("GetArtistByUserName/{userName}")]
        [ProducesResponseType(typeof(IEnumerable<ArtistResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ArtistResponse>>> GetArtistByUserName(string userName)
        {
            var query = new GetArtistByNameQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        //Added for testing purpose
        [HttpPost("CreateArtist")]
        [ProducesResponseType(typeof(ArtistResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //Added for testing purpose
        [HttpPut("EditArtist")]
        [ProducesResponseType(typeof(ArtistResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateArtist([FromBody] UpdateArtistCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("DeleteArtist")]
        [ProducesResponseType(typeof(ArtistResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteArtist([FromBody] DeleteArtistCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
