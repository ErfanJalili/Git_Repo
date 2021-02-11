using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Application;
using Music.Application.CQRS.Music.Command;
using Music.Application.CQRS.Music.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Music.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MusicController> _logger;

        public MusicController(IMediator mediator, ILogger<MusicController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetAllMusic")]
        [ProducesResponseType(typeof(IEnumerable<MusicResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MusicResponse>>> GetAllMusic()
        {
            var query = new GetAllMusicQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("GetMusicByUsername/{userName}")]
        [ProducesResponseType(typeof(IEnumerable<MusicResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MusicResponse>>> GetMusicByUsername(string userName)
        {
            var query = new GetMusicByArtistNameQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("GetMusicById/{id}")]
        [ProducesResponseType(typeof(IEnumerable<MusicResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MusicResponse>>> GetMusicById(int id)
        {
            var query = new GetMusicByIdQuery(id);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        //Added for testing purpose
        [HttpPost("CreateMusic")]
        [ProducesResponseType(typeof(MusicResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateMusic([FromBody] CreateMusicCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //Added for testing purpose
        [HttpPut("EditMusic")]
        [ProducesResponseType(typeof(MusicResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMusic([FromBody] UpdateMusicCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("DeleteMusic")]
        [ProducesResponseType(typeof(MusicResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMusic([FromBody] DeleteMusicCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
