using System.Collections.Generic;

namespace ShelfDisplay
{
    /// <summary>
    /// This class represent a list of ProductData for a list of products that fetch from the server. 
    /// </summary>
    [System.Serializable]
    public class ProductsDataStorage
    {
        public List<ProductData> products;
    }
}
