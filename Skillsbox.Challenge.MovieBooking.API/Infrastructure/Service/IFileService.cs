namespace Skillsbox.Challenge.MovieBooking.API.Infrastructure.Service
{
    public interface IFileService
    {
        public string SaveFileToFileSystem(IFormFile file);
    }
}
