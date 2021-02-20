using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Models
{
    public class NumbersSet
    {
        private const string onlyFoIntegersConstraint = @"^\d+( \d+)*$";

        [Required]
        [RegularExpression(onlyFoIntegersConstraint, ErrorMessage = "Data string in wrong format or contains non-integer items(Must be a string of integers separated by spaces).")]
        public string Numbers { get; set; }
    }
}
