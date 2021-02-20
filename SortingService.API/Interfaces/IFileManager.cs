using System;
using System.Threading.Tasks;

namespace SortingService.API.Interfaces
{
    public interface IFileManager
    {
        Task<string> WriteToFile(int[] content);

        string GetPathToResult(string token);
    }
}