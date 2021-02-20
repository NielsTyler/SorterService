using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Queries
{
    public class GetFilePathByTokenQuery: IRequest<string>
    {
        public Guid FileToken { get; }

        public GetFilePathByTokenQuery(Guid token)
        {
            FileToken = token;
        }
    }
}
