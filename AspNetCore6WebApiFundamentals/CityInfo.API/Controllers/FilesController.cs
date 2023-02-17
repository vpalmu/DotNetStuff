using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            this._fileExtensionContentTypeProvider = fileExtensionContentTypeProvider 
                                                    ?? throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));  

        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var path = "Files/Symptom diaries DB.PNG";
            if (!System.IO.File.Exists(path)) return NotFound();

            if(_fileExtensionContentTypeProvider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream"; // default media type of arbitrary binary data
            }

            var bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, contentType, Path.GetFileName(path));
        }
    }
}
