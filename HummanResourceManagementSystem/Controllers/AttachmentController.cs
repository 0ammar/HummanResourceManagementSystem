using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace HummanResourceManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public async Task<string> UploadImageAndGetURL(IFormFile file)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (file == null || file.Length == 0)
            {
                throw new Exception("Please Enter Valid File");
            }
            string newFileURL = DateTime.Now.ToString() + "" + file.FileName;
            string newFileURL2 = Guid.NewGuid().ToString() + "" + file.FileName;
            using (var inputFile = new FileStream(Path.Combine(uploadFolder, newFileURL2), FileMode.Create))
            {
                await file.CopyToAsync(inputFile);
            }
            return newFileURL2;
        }
        [HttpGet("{fileName}")]
        public IActionResult GetFile(string fileName)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name is not provided");
            }

            var filePath = Path.Combine(uploadFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

            var contentType = GetContentType(filePath);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, contentType, fileName);
        }

        [HttpDelete("{fileName}")]
        public IActionResult RemoveFile(string fileName)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name is not provided");
            }

            var filePath = Path.Combine(uploadFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }
            System.IO.File.Delete(filePath);

            return Ok("File Got Removed");
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

    }
}
