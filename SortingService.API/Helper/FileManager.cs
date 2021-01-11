using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SortingService.API.Exceptions;
using System;
using System.IO;

namespace SortingService.API.Helper
{
    public class FileManager
    {
        private ILogger<FileManager> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _fileName;
        private readonly string _path;

        public string PathToResult => _path; 

        public FileManager(ILogger<FileManager> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            _fileName = _configuration["ResultFileName"];
            _path = Path.Combine(
                     Directory.GetCurrentDirectory(),
                     "wwwroot", _fileName);
        }
        public void SaveToFile(int[] data)
        {
            try 
            {
                using (var writer = File.CreateText(_path))
                {
                    writer.WriteLine(NumbersDataConverter.Convert(data));
                }

            } catch (Exception ex)
            {
                string errMessage = $"Error writing result to a file. File name: {_fileName}";
                _logger.LogError(errMessage, ex);

                throw new SSException(errMessage);
            }
        }                
    }
}
