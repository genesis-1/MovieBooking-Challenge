using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.Core.Entities;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;


namespace Skillsbox.Challenge.MovieBooking.API.Model.Booking
{
    public class Create
    {
        public class CreateBookingCommand : IRequest<CommandResponse>
        {
            public int MovieId { get; set; }
            public string MovieBookedBy { get; set; }
            public DateTime MovieBookedon { get; set; }

            public string BookedTime { get; set; }

            public string BookingOwnerEmail { get; set; }

            public ICollection<SeatDto> BookedSeats { get; set; }
            public ICollection<AgeCategoryDetailDto> AgeCategoryDetails { get; set; }
            public TicketDto Ticket { get; set; }

        }


        public class CommandResponse
        {
            public int Id { get; set; }
        }

        public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
        {
            /// <summary>
            ///     Validator ctor
            /// </summary>
            public CreateBookingCommandValidator()
            {

            }

        }

        public class CommandHandler : IRequestHandler<CreateBookingCommand, CommandResponse>
        {
            private readonly IUnitOfWork _repo;
            private readonly IMapper _mapper;

            public CommandHandler(IUnitOfWork repo,
                                  IMapper mapper)
            {
                this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
                this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CommandResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
            {

                CommandResponse response = new();

                var ticketToSave = _mapper.Map<Ticket>(request.Ticket);
                var totalPricePerAgeCategories = request.AgeCategoryDetails.Sum(x => x.TotalPriceForAnAgeCategory);
                ticketToSave.TotalPricePerAgeCategories = totalPricePerAgeCategories;
                ticketToSave.TotalNumberOfTicketsTobeBooked = (int)request.AgeCategoryDetails.Sum(x => x.AgeCategoryUnits);

                Core.Entities.Booking BookingToSaveInDb = _mapper.Map<Core.Entities.Booking>(request);
                BookingToSaveInDb.TotalBookedSeats = ticketToSave.TotalNumberOfTicketsTobeBooked;

                await _repo.BookingRepository.AddAsync(BookingToSaveInDb);

                ticketToSave.BookingId = BookingToSaveInDb.Id;
                await _repo.TicketRepository.AddAsync(ticketToSave);

                var ageCategoryDetails = AssociateAgeCategoryDetailWithTicketAndBooking( ticketToSave, request.AgeCategoryDetails);
                var seats = AssociateSeatsWithBooking(BookingToSaveInDb.Id, request.BookedSeats);

                await _repo.AgeCategoryDetailRepository.AddRange(ageCategoryDetails);
                await _repo.SeatsRepository.AddRange(seats);
                response.Id = BookingToSaveInDb.Id;
                return response;



            }

            private IEnumerable<Seat> AssociateSeatsWithBooking(int id, ICollection<SeatDto> bookedSeats)
            {
                var seatListTOSave = new List<Seat>();

                var currentSeatList = _mapper.Map<IEnumerable<Seat>>(bookedSeats);

                foreach (var seat in currentSeatList)
                {
                    seat.BookingId = id;
                    seatListTOSave.Add(seat);
                }

                return seatListTOSave;
            }

            private IEnumerable<AgeCategoryDetail> AssociateAgeCategoryDetailWithTicketAndBooking(Ticket ticketToSave, ICollection<AgeCategoryDetailDto> ageCategoryDetails)
            {
                var ageCategoryDetailListTOSave = new List<AgeCategoryDetail>();

                var currentAgeCategoryList = _mapper.Map<IEnumerable<AgeCategoryDetail>>(ageCategoryDetails);

                foreach (var ageCategoryDetail in currentAgeCategoryList)
                {
                    ageCategoryDetail.TicketId = ticketToSave.Id;
                    ageCategoryDetailListTOSave.Add(ageCategoryDetail);
                }

                return ageCategoryDetailListTOSave;
            }
        }
    }
}
