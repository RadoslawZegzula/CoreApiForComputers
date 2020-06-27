
using System.ComponentModel.DataAnnotations;

namespace CoreApiForComputers.Models.Entities
{
    /// <summary>
    /// The model of central_processing_unit which purpose is to be stored and retrieved from database
    /// </summary>
    public class CpuEntity : BaseEntityOfParts
    {
        /// <summary>
        /// The frequency of central_processing_unit
        /// </summary>
        [Range(0, 100000, ErrorMessage = "Frequency value is too high or negative")]
        public int Frequency { get; set; }

        /// <summary>
        /// The number of cores in the central_processing_unit
        /// </summary>    
        [Range(0, 10000, ErrorMessage = "Cores ammount is too high or negative")]
        public int Cores { get; set; }

        /// <summary>
        /// The required motherboard socket for central_processing_unit
        /// </summary>      
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Socket { get; set; }

        /// <summary>
        /// The thermal_design_power of central_processing_unit
        /// </summary>
        [Range(0, 100000, ErrorMessage = "The thermal_design_power is too high or negative")]
        public float Tdp { get; set; }
    }
}
