using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SortingService.API.Helper;
using SortingService.API.Interfaces;
using SortingService.API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            services.AddScoped<IFileManager, FileManager>();
            services.AddScoped<ISortingService, BubbleSorter>();
            services.AddMediatR(typeof(Startup));
        }
    }
}
