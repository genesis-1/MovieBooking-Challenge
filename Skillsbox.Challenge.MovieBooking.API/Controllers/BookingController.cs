using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skillsbox.Challenge.MovieBooking.API.Infrastructure.Service;
using Skillsbox.Challenge.MovieBooking.API.Model.Booking;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using System.Net.Http.Headers;

namespace Skillsbox.Challenge.MovieBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Create([FromBody] Create.CreateBookingCommand command)
        {
            try
            {

                Create.CommandResponse response = await _mediator.Send(command);
                return CreatedAtRoute("GetBooking", new { id = response.Id }, null);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "GetBooking")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Booking>> Get(int id)
        {
            Get.QueryResponse response = await _mediator.Send(new Get.GetQuery() { Id = id });

            return response.GetBooking;
        }

    }
}
