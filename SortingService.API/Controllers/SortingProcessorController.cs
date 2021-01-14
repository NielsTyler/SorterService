using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SortingService.API.Exceptions;
using SortingService.API.Helper;
using SortingService.API.Interfaces;
using SortingService.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SortingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SortingProcessorController : ControllerBase
    {        
        private readonly ILogger<SortingProcessorController> _logger;
        private readonly ISortingService _sortingService;
        private readonly FileManager _fileManager;

        public SortingProcessorController(ILogger<SortingProcessorController> logger, ISortingService sortingService, FileManager fileManager)
        {
            _logger = logger;
            _sortingService = sortingService;
            _fileManager = fileManager;
        }

        [HttpPost]
        [Route("order")]
        public IActionResult OrderAndSave([FromBody] NumbersSet data)
        {
            _logger.LogInformation("Start ordering numbers.");

            int[] numbersArray = NumbersDataConverter.Convert(data.Numbers);

            _sortingService.Sort(numbersArray);

            _fileManager.SaveToFile(numbersArray);
            return Ok();
        }

        [HttpGet]
        [Route("result")]
        public async Task<IActionResult> DownloadResult()
        {
            _logger.LogInformation("Start downloading result.");

            var memory = new MemoryStream();
            string pathToResult = _fileManager.GetPathToResult();           

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
