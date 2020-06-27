using System;
using System.ComponentModel.DataAnnotations;

namespace CoreApiForComputers.Models.Entities
{
    /// <summary>
    /// The model of graphics_processing_unit which purpose is to be stored and retrieved from database
    /// </summary>
    public class GpuEntity : BaseEntityOfParts
    {
        /// <summary>
        /// Manufacturer of a chipset
        /// </summary>
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string ChipsetManufacturer { get; set; }

        /// <summary>
        /// Name of a chipset
        /// </summary>
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Chipset { get; set; }

        /// <summary>
        /// The frequency in megahertz of graphics_processing_unit 
        /// </summary>
        [Range(0, 1000000, ErrorMessage = "Cores ammount is too high or negative")]
        public int Frequency { get; set; }

        /// <summary>
        /// The frequency in megahertz of graphics_processing_unit in a a boost mode 
        /// </summary>
        [Range(0, 100000, ErrorMessage = "Frequency value is too high or negative")]
        public int OverclockedFrequency { get; set; }

        /// <summary>
        /// The typeof
        /// </summary>
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string ConnectorType { get; set; }

        /// <summary>
        /// The Length of a card in milimetres
        /// </summary>
        [Range(0, 1000000, ErrorMessage = "Length of card in milimetres is too high or negative")]
        public int LengthOfCard { get; set; }
    }
}
