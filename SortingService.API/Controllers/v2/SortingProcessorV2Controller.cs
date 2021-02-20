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
    public partial class SortingProcessorController : ControllerBase
    {                                     
        [HttpPost]
        [Route("order")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> OrderAndSaveV2([FromBody] NumbersSet data)
        {
            string res = "ver 2.0 is UNDER CONSTRACTION"; 
                      
            return Ok(res);
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetResultFileV2([FromHeader, Required]Guid fileToken)
        {
            string res = "ver 2.0 is UNDER CONSTRACTION";

            return Ok(res);
        }
    }
}
