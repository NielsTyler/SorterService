using MediatR;
using SortingService.API.Helper;
using SortingService.API.Interfaces;
using SortingService.API.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortingService.API.Handlers
{
    public class GetFilePathHandler : IRequestHandler<GetFileQuery, string>
    {
        private readonly IFileManager _fileManager;
        public GetFilePathHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<string> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            //Doesn't work properly due to wrong guid
            return await Task.Run(() => _fileManager.GetPathToResult(Guid.NewGuid().ToString()));
        }
    }
}
