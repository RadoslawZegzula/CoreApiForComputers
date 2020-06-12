using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.Models.Entities
{
    public class BaseEntityOfParts
    {
        /// <summary>
        /// The uniquely identifier of part
        /// </summary>
        [Required()]
        public int Id { get; set; }

        [Required()]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public string Manufacturer { get; set; }
    }
}
