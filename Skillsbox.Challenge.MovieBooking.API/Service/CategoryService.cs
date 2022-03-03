using Skillsbox.Challenge.MovieBooking.Business.Repository;
using Skillsbox.Challenge.MovieBooking.Model;

namespace Skillsbox.Challenge.MovieBooking.API
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> Create(CategoryDTO objDTO)
        {
           var createdCategory = _categoryRepository.Create(objDTO);
            return Results.Created($"/categories/{createdCategory.Result.Id}", createdCategory.Result);
        }

        public async Task<IResult> Delete(int id)
        {
            await _categoryRepository.Delete(id);
            return Results.NoContent();
        }

        public async Task<IResult> Get(int id)
        {
           var category = await  _categoryRepository.Get(id);

            return category != null ? Results.Ok(category) : Results.NotFound();

        }

        public async Task<IResult> GetAll()
        {
            var categories = await _categoryRepository.GetAll();

            return Results.Ok(categories);

        }

        public async Task<IResult> Update(CategoryDTO objDTO)
        {
            var updatedCategory = await _categoryRepository.Update(objDTO);

            return Results.Ok(updatedCategory);
        }
    }
}
