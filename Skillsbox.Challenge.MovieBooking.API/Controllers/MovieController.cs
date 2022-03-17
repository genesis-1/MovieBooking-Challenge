using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skillsbox.Challenge.MovieBooking.API.Model.Movie;

namespace Skillsbox.Challenge.MovieBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Movie
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<MovieArray>> GetAll()
        {
            GetAll.QueryResponse response = await _mediator.Send(new GetAll.GetAllQuery());
            return response.Resource;
        }
    }
}
