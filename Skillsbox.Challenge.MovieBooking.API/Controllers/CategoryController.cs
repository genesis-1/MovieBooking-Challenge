using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skillsbox.Challenge.MovieBooking.API.Model.Category;

namespace Skillsbox.Challenge.MovieBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Category
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            GetAll.QueryResponse response = await _mediator.Send(new GetAll.GetAllQuery());
            return response.Resource;
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            Get.QueryResponse response = await _mediator.Send(new Get.GetQuery() { Id = id });

            return response.Category;
        }
        // POST: api/Category
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Create([FromBody] Create.CreateCategoryCommand command)
        {
            Create.CommandResponse response = await _mediator.Send(command);
            return CreatedAtRoute("GetCategory", new { id = response.Id }, null);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Update))]
        public async Task<IActionResult> Update(int id, [FromBody] Update.UpdateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            Update.CommandResponse response = await _mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new Delete.DeleteCategoryCommand() { Id = id });

            return NoContent();
        }

    }
}
