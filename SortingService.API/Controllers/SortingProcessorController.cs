using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SortingService.API.Commands;
using SortingService.API.Exceptions;
using SortingService.API.Helper;
using SortingService.API.Interfaces;
using SortingService.API.Models;
using SortingService.API.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SortingService.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/SortingProcessor")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public partial class SortingProcessorController : ControllerBase
    {                       
        private readonly IMediator _mediator;

        public SortingProcessorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("order")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> OrderAndSave([FromBody] NumbersSet data)
        {
            var sortingCommand = new SortingNumbersCommand(data.Numbers);
            string fileToken = await _mediator.Send<string>(sortingCommand); 
                      
            return Ok(fileToken);
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetResultFile([FromHeader, Required]Guid fileToken)
        {
            var query2 = new GetFilePathByTokenQuery(fileToken);
            string pathToFile = await _mediator.Send(query2);

            if (String.IsNullOrEmpty(pathToFile))
                return NotFound();

            var query = new GetFileQuery();
            var filePath = await _mediator.Send(query);

            var memory = new MemoryStream();
            string pathToResult = filePath;

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
