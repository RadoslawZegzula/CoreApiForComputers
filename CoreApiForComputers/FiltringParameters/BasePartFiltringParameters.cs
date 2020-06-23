
namespace CoreApiForComputers.FiltringParameters
{
    /// <summary>
    /// This class is used as
    /// parameter in filtring method
    /// </summary>
    public class BasePartFiltringParameters
    {
        /// <summary>
        /// Minimumm price of a product
        /// </summary>
        public decimal? MinPrice { get; set; }

        /// <summary>
        /// Maximum price of a product
        /// </summary>
        public decimal? MaxPrice { get; set; }

    }
}
