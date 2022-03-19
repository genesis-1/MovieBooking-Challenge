using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skillsbox.Challenge.MovieBooking.API.Infrastructure.Service;
using Skillsbox.Challenge.MovieBooking.API.Model.Movie;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using System.Net.Http.Headers;
using static Skillsbox.Challenge.MovieBooking.API.Model.Movie.GetAll;

namespace Skillsbox.Challenge.MovieBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFileService _fileService;

        public MovieController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        // GET: api/Movie
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<Movie>> GetAll([FromQuery] GetAllQuery movieParameters)
        {
            GetAll.QueryResponse response = await _mediator.Send(movieParameters);
            return response.Resource;
        }

        // POST: api/Movie
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Create([FromBody] Create.CreateMovieCommand command)
        {
            try
            {

                Create.CommandResponse response = await _mediator.Send(command);
                return CreatedAtRoute("GetMovie", new { id = response.Id }, null);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "GetMovie")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            Get.QueryResponse response = await _mediator.Send(new Get.GetQuery() { Id = id });

            return response.GetMovie;
        }

    }
}
