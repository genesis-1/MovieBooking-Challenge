using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.Core.Persistence
{
     public interface IUnitOfWork : IDisposable
    {
        IRunningDayRepository RunningDayRepository { get; }
        IRunningHourAndMinuteRepository RunningHourAndMinuteRepository { get; }
        IRunningTimeRepository RunningTimeRepository { get; }
        IMovieRepository MovieRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IBookingRepository BookingRepository { get; }
        ISeatRepository SeatsRepository { get; }
        ITicketRepository TicketRepository { get; }
        IAgeCategoryDetailRepository AgeCategoryDetailRepository { get; }

        void Save();
    }
}
