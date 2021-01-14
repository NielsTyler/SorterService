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
        [RegularExpression(onlyFoIntegersConstraint, ErrorMessage = "Data string in wrong format or contains non-integer items.(Should be string of integer with spaces)")]
        public string Numbers { get; set; }
    }
}
