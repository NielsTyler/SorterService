using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SortingService.API.Models
{
    public class NumbersSet
    {
        [Required]
        public string Numbers { get; set; }
    }
}
