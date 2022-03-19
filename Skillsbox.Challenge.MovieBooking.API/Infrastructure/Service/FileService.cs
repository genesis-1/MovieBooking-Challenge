using System.Net.Http.Headers;

namespace Skillsbox.Challenge.MovieBooking.API.Infrastructure.Service
{
    public class FileService : IFileService
    {
        public string SaveFileToFileSystem(IFormFile file)
        {
            try
            {
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathTosave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var dbPath = string.Empty;

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathTosave, fileName);
                    dbPath = Path.Combine(folderName, fileName);

                    using var stream = new FileStream(fullPath, FileMode.Create);
                    file.CopyTo(stream);
                }


                return dbPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Failed to upload the Movie File");
            }
            
        }
    }
}
