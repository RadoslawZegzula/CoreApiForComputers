using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.Models.Entities
{
    /// <summary>
    /// The model of central_processing_unit which purpose is to be stored and retrieved from database
    /// </summary>
    public class CpuEntity
    {
        /// <summary>
        /// The Id of central_processing_unit
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The frequency of central_processing_unit
        /// </summary>
        public int Frequency { get; set; }
        /// <summary>
        /// The number of cores in the central_processing_unit
        /// </summary>
        public int Cores { get; set; }
        /// <summary>
        /// The required motherboard socket for central_processing_unit
        /// </summary>
        public string Socket { get; set; }
        /// <summary>
        /// The thermal_design_power of central_processing_unit
        /// </summary>
        public float Tdp { get; set; }
    }
}
