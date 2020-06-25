
namespace CoreApiForComputers.FiltringParameters
{
    /// <summary>
    /// This class is used as
    /// parameter in filtring method
    /// </summary>
    public class BasePartFiltringParameters
    {
        /// <summary>
        /// The minimum price of a product
        /// </summary>
        public decimal? MinPrice { get; set; }

        /// <summary>
        /// The maximum price of a product
        /// </summary>
        public decimal? MaxPrice { get; set; }

    }
}
