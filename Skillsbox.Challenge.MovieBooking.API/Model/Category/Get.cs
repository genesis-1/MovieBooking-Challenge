using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.Core.Exceptions;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Category
{
    public class Get
    {
        public class GetQuery : IRequest<QueryResponse>
        {

            public int Id { get; set; }
        }

        public class QueryResponse
        {
            public CategoryDto Category { get; set; }
        }

        public class GetCategoryQueryValidator : AbstractValidator<GetQuery>
        {
            /// <summary>
            ///     Validator ctor
            /// </summary>
            public GetCategoryQueryValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty();
            }

        }

        public class QueryHandler : IRequestHandler<GetQuery, QueryResponse>
        {
            private readonly IUnitOfWork _repo; 
            private readonly IMapper _mapper;
            public QueryHandler(IUnitOfWork repo, IMapper mapper)
            {
                this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
                this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<QueryResponse> Handle(GetQuery request, CancellationToken cancellationToken)
            {
                QueryResponse response = new();

                Core.Entities.Category category = await _repo.CategoryRepository.GetByIdAsync(request.Id);
                if(category == null)
                {
                    throw new EntityNotFoundException(nameof(Category), request.Id);
                }

                response.Category = _mapper.Map<CategoryDto>(category);
                return response;
            }
        }

    }


}
