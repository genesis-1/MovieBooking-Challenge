using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;
using System.Net.Http.Headers;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class Create
    {
        public class CreateMovieCommand : IRequest<CommandResponse>
        {

            public string? Title { get; set; }
            public int Year { get; set; }
            public string Director { get; set; }
            public string Cast { get; set; }
            public string Genre { get; set; }
            public string Notes { get; set; }
            public string ImageUrl { get; set; }
            public decimal Duration { get; set; }

        }


        public class CommandResponse
        {
            public int Id { get; set; }
        }

        public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
        {
            /// <summary>
            ///     Validator ctor
            /// </summary>
            public CreateMovieCommandValidator()
            {
                
            }

        }

        public class CommandHandler : IRequestHandler<CreateMovieCommand, CommandResponse>
        {
            private readonly IUnitOfWork _repo;
            private readonly IMapper _mapper;

            public CommandHandler(IUnitOfWork repo,
                                  IMapper mapper)
            {
                this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
                this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
            {
                
                    CommandResponse response = new();
                    
                    
                    Core.Entities.Movie movieToSaveInDb = _mapper.Map<Core.Entities.Movie>(request);
                    await _repo.MovieRepository.AddAsync(movieToSaveInDb);
                    response.Id = movieToSaveInDb.Id;
                    return response;


                
            }
        }
    }
}
