using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SortingService.API.Exceptions;
using SortingService.API.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SortingService.API.Helper
{
    public class FileManager : IFileManager
    {
        private ILogger<FileManager> _logger;
        private const string FILE_NAME = "result";
        private const string FILE_EXT = "txt";

        public FileManager(ILogger<FileManager> logger)
        {
            _logger = logger;            
        }

        private string GetFileNameByGuid(string token)
        {
            return $"{FILE_NAME}_{token}.{FILE_EXT}";
        }

        public string GetFilePathByToken(string token)
        {
            return Path.Combine(
                     Directory.GetCurrentDirectory(),
                     GetFileNameByGuid(token));
        }

        public async Task<string> WriteToFile(int[] content)
        {
            string fileToken = Guid.NewGuid().ToString();
            string filePath = GetFilePathByToken(fileToken);

            try
            {
                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                    await outputFile.WriteAsync(NumbersDataConverter.Convert(content));

                    return fileToken.ToString();
                }
            }
            catch (Exception ex)
            {
                string errMessage = $"Error writing result to a file. File path : \"{filePath}\"";
                _logger.LogError(errMessage, ex);

                throw new SSException() { Value = errMessage };
            }
        }

        public string GetPathToResult(string token)
        {
            string filePath = GetFilePathByToken(token);

            if (!File.Exists(filePath))
            {
                throw new SSException() { Value = "Result file not found.", Status = (int)HttpStatusCode.NotFound };
            }

            return filePath;
        } 
    }
}
