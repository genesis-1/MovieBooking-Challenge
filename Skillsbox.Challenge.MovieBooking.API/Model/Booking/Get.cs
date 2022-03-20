using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.Core.Exceptions;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Booking
{
    public class Get
    {
        public class GetQuery : IRequest<QueryResponse>
        {

            public int Id { get; set; }
        }

        public class QueryResponse
        {
            public Core.Entities.Booking GetBooking { get; set; }
        }

        public class GetBookingQueryValidator : AbstractValidator<GetQuery>
        {
            /// <summary>
            ///     Validator ctor
            /// </summary>
            public GetBookingQueryValidator()
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

                Core.Entities.Booking booking = await _repo.BookingRepository.GetFistOrDefaultByCreteriaAsync(filter: x => x.Id == request.Id, includeProperties: "Ticket.AgeCategoryDetails,BookedSeats");
                if (booking == null)
                {
                    throw new EntityNotFoundException(nameof(booking), request.Id);
                }

                response.GetBooking = booking;
                return response;
            }
        }

    }
}
