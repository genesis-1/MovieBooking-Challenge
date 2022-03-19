
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.API.Infrastructure.Helper;
using Skillsbox.Challenge.MovieBooking.API.Service;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class GetAll
    {
        public class GetAllQuery : IRequest<QueryResponse>
        {
            public GetAllQuery()
            {
                PageNumber = 1;
                PageSize = 6;
            }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }

        public class MovieParameters : QueryStringParameters
        {
            public MovieParameters()
            {
            }
        }

        public class QueryResponse
        {
            /// <summary>
            ///     Resource
            /// </summary>
            public PagedList<Core.Entities.Movie> Resource { get; set; }
        }

        public class GetAllMoviesQueryValidator : AbstractValidator<GetAllQuery>
        {
            /// <summary>
            ///     Validator ctor
            /// </summary>
            public GetAllMoviesQueryValidator()
            {

            }

        }

        public class QueryHandler : IRequestHandler<GetAllQuery, QueryResponse>
        {
            private readonly IMovieService _movieService;
            private readonly IUnitOfWork _repo;
            public Random rand = new Random();
            int randomNumber = 0;
            public List<int> generatedRandonNumbers = new List<int>();

            public QueryHandler(IMovieService movieService,
                IUnitOfWork repo
                    )
            {
                _repo = repo;
                _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));

            }

            private int GetRandomId()
            {
                randomNumber = rand.Next(0, 1000);
                while(!generatedRandonNumbers.Contains(randomNumber))
                {
                    //randomNumber = rand.Next(0, 1000);
                    generatedRandonNumbers.Add(randomNumber);
                   /// randomNumber = rand.Next(0, 1000);

                }
                return randomNumber;
            }

            public async Task<QueryResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
                QueryResponse response = new();

                try
                {
                    var movies = await _repo.MovieRepository.GetAllByCriteriaAsync(includeProperties: "RunningTime.RunningDays.RunningHourAndMinutes");

                    var pageMovies = await PagedList<Core.Entities.Movie>.ToPagedList(movies, request.PageNumber, request.PageSize);

                    response.Resource = pageMovies;

                    return response;


                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex);
              
                }
                
            }
        }
    }
}