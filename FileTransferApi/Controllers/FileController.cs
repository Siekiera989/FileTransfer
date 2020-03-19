using System.Threading.Tasks;
using FileTransferApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FileTransferApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task SaveSomeText2([FromQuery] string someText) => await Task.Run(()=>_fileService.EnterIntoFile(someText));

        [HttpPost]
        public async  Task SaveSomeText([FromQuery] string someText) => await Task.Run(()=>_fileService.EnterIntoFile(someText));
    }
}