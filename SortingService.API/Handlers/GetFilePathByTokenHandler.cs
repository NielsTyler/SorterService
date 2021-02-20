using MediatR;
using SortingService.API.Interfaces;
using SortingService.API.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortingService.API.Handlers
{
    public class GetFilePathByTokenHandler : IRequestHandler<GetFilePathByTokenQuery, string>
    {
        private readonly IFileManager _fileManager;
        public GetFilePathByTokenHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }
        public async Task<string> Handle(GetFilePathByTokenQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _fileManager.GetPathToResult(request.FileToken.ToString()));
        }
    }
}
