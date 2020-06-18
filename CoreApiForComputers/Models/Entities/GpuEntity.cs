using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string ChipsetManufacturer { get; set; }

        /// <summary>
        /// Name of a chipset
        /// </summary>
        public string Chipset { get; set; }

        /// <summary>
        /// The frequency in megahertz of graphics_processing_unit 
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// The frequency in megahertz of graphics_processing_unit in a a boost mode 
        /// </summary>
        public int OverclockedFrequency { get; set; }

        /// <summary>
        /// The typeof
        /// </summary>
        public string ConnectorType { get; set; }

        /// <summary>
        /// The Length of a card in milimetres
        /// </summary>
        public int LengthOfCard { get; set; }
    }
}
