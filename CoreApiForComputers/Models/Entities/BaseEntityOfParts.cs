
using System.ComponentModel.DataAnnotations;

namespace CoreApiForComputers.Models.Entities
{
    /// <summary>
    /// Provides common properties to reduce redundancy
    /// </summary>
    public class BaseEntityOfParts
    {
        /// <summary>
        /// The uniquely identifier of part
        /// </summary>
        [Required()]
        public int Id { get; set; }

        /// <summary>
        /// Name of the part
        /// </summary>
        [Required()]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        
        /// <summary>
        /// The price of a part
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The url to a image of a part
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// The number of parts that
        /// are available
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// The name of a company that
        /// created this part
        /// </summary>
        public string Manufacturer { get; set; }
    }
}
