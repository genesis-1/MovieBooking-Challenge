using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Extensions
{
    public static class CacheHelpers
    {
        public static string GenerateCategoriesCacheKey()
        {
            return "categories";
        }
    }
}
