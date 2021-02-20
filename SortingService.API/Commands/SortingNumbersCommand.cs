using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Commands
{
    public class SortingNumbersCommand : IRequest<string>
    {
        public string Numbers { get; set; }
        public SortingNumbersCommand(string numbers)
        {
            Numbers = numbers;
        }
    }
}
