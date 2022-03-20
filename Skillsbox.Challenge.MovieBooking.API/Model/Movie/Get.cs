using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.Core.Exceptions;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class Get
    {
        public class GetQuery : IRequest<QueryResponse>
        {

            public int Id { get; set; }
        }

        public class QueryResponse
        {
            public Core.Entities.Movie GetMovie { get; set; }
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

                Core.Entities.Movie movie = await _repo.MovieRepository.GetFistOrDefaultByCreteriaAsync(filter:x => x.Id == request.Id,includeProperties: "RunningTime.RunningDays.RunningHourAndMinutes");
                if (movie == null)
                {
                    throw new EntityNotFoundException(nameof(Movie), request.Id);
                }

                response.GetMovie = movie;
                return response;
            }
        }

    }
}
