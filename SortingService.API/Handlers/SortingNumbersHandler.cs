using MediatR;
using Microsoft.Extensions.Logging;
using SortingService.API.Commands;
using SortingService.API.Exceptions;
using SortingService.API.Helper;
using SortingService.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortingService.API.Handlers
{
    public class SortingNumbersHandler : IRequestHandler<SortingNumbersCommand, string>
    {
        private readonly ILogger<SortingNumbersHandler> _logger;
        private readonly ISortingService _sortingService;
        private readonly IFileManager _fileManager;
        public SortingNumbersHandler(ILogger<SortingNumbersHandler> logger, ISortingService sortingService, IFileManager fileManager)
        {
            _logger = logger;
            _sortingService = sortingService;
            _fileManager = fileManager;
        }
        public async Task<string> Handle(SortingNumbersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int[] numbersArray = NumbersDataConverter.Convert(request.Numbers);
                _sortingService.Sort(numbersArray);

                //await if accepted and async req reply pattern
                return await _fileManager.WriteToFile(numbersArray);
            }
            catch (Exception ex)
            {
                _logger.LogError("An unhandled error occurred.", ex);

                throw new SSException("Sorry, something goes wrong on our server. Please, write to our support: dvtsvetkov@gmail.com");
            }
        }
    }
}
