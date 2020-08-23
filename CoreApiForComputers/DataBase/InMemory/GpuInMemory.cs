using CoreApiForComputers.Models.Entities;
using System.Collections.Generic;

namespace CoreApiForComputers.DataBase.InMemory
{
    /// <summary>
    /// Stores graphics_processing_units
    /// in a memory
    /// </summary>
    public static class GpuInMemory
    {
        private static readonly List<GpuEntity> gpus;

        static GpuInMemory()
        {
            gpus = new List<GpuEntity>()
            {
            new GpuEntity()
            {
                Id = 1,
                Name = "GpuName1"
            },
            new GpuEntity()
            {
                Id = 2,
                Name = "GpuName2"
            },
            new GpuEntity()
            {
                Id = 3,
                Name = "GpuName3"
            },
            };
        }

        /// <summary>
        /// Returns a graphics_processing_units
        /// </summary>
        /// <returns>The list of graphics_processing_units </returns>
        public static List<GpuEntity> ReturnGpus()
        {
            return gpus;
        }
    }
}

