using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Queries
{
    public class GetFileQuery: IRequest<string>
    {
    }
}
