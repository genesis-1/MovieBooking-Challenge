using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.API.Service;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
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
            public IEnumerable<MovieArray> Resource { get; set; }
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
            private readonly IMapper _mapper;
            public Random rand = new Random();
            int randomNumber = 0;
            public List<int> generatedRandonNumbers = new List<int>();

            public QueryHandler(IMovieService movieService,
                IUnitOfWork repo,
                IMapper mapper
                    )
            {
                _repo = repo;
                _mapper = mapper;
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
                    IEnumerable<MovieArray> movies = await _movieService.GetAllAsync();

                    
                    response.Resource = movies;

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