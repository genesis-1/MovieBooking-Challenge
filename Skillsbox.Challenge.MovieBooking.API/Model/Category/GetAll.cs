using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;
using static Skillsbox.Challenge.MovieBooking.API.Model.Category.Get;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Category
{
    public class GetAll
    {
        public class GetAllQuery : IRequest<QueryResponse>
        {

        }

        public class QueryResponse
        {
            /// <summary>
            ///     Resource
            /// </summary>
            public IEnumerable<CategoryDto> Resource { get; set; }
        }

        public class GetAllCategoriesQueryValidator : AbstractValidator<GetAllQuery>
        {
            /// <summary>
            ///     Validator ctor
            /// </summary>
            public GetAllCategoriesQueryValidator()
            {

            }

        }

        public class QueryHandler : IRequestHandler<GetAllQuery, QueryResponse>
        {
            private readonly IUnitOfWork _repo;
            private readonly IMapper _mapper;

            public QueryHandler(IUnitOfWork repo,
                    IMapper mapper
                    )
            {
                this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
                this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
               
            }

            public async Task<QueryResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
                QueryResponse response = new();

                IEnumerable<Core.Entities.Category> categories = await _repo.CategoryRepository.GetAllAsync();
                response.Resource = categories.Select(x => _mapper.Map<CategoryDto>(x));

                return response;
            }
        }

    }
}
