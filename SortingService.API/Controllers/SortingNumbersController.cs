using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SortingService.API.Helper;
using SortingService.API.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SortingNumbersController : ControllerBase
    {        
        private readonly ILogger<SortingNumbersController> _logger;
        private readonly ISortingService _sortingService;
        private readonly FileManager _fileManager;

        public SortingNumbersController(ILogger<SortingNumbersController> logger, ISortingService sortingService, FileManager fileManager)
        {
            _logger = logger;
            _sortingService = sortingService;
            _fileManager = fileManager;
        }

        [HttpPost]
        [Route("order")]
        public IActionResult Order(string numbers)
        {
            _logger.LogInformation("Start ordering numbers.");

            int[] numbersArray = NumbersDataConverter.ValidateAndConvert(numbers);

            if (numbersArray != null && numbersArray.Length > 0)
            {
                _sortingService.Sort(numbersArray);
            }
            else
                throw new ArgumentException(
                    $"Numbers parameter cannot be empty or 0.");

            _fileManager.SaveToFile(numbersArray);
            return Ok();
        }

        [HttpGet]
        [Route("result")]
        public async Task<IActionResult> DownloadResult()
        {
            _logger.LogInformation("Start downloading result.");

            var memory = new MemoryStream();
            string pathToResult = _fileManager.PathToResult;

            using (var stream = new FileStream(pathToResult, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            string mimeType = "application/octet-stream";

            return File(memory, mimeType, Path.GetFileName(pathToResult));
        }
    }
}
