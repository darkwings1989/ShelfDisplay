using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShelfDisplay
{
    /// <summary>
    /// This class responsible to be the communication between the model (data) and the view in this app.
    /// </summary>
    public class ShelfDisplayController : MonoBehaviour
    {
        // The ProductViews that will show the product data from the sever.
        [SerializeField] private List<ProductView> m_ProductViews;
        // The popup that will allow to make changes to a ProductView data.
        [SerializeField] private EditProductViewPopup m_EditProductViewPopup;
        
        // This list is storing locally the last products fetched from the sever.
        private List<ProductData> m_Products = new List<ProductData>();


        private void Start()
        {
            RefreshProductsAction();
        }
        
        /// <summary>
        /// This method fetch new products from the sever and refresh the view with new data.
        /// </summary>
        public async void RefreshProductsAction()
        {
            // Hide all products view before refreshing the shelf.
            HideProductViews();
            
            // Fetch new products from the server.
            if (ServerCommunication.SharedInstance != null)
            {
                ProductsDataStorage productsDataStorage = await ServerCommunication.SharedInstance.GetProducts();
                
                m_Products = new List<ProductData>(productsDataStorage.products);
            }
                
            // Update Products shelf view with the products data that was fetched from the server.
            UpdateShelfDisplayView();
        }
        
        // Private methods.
        
        /// <summary>
        /// This method will update the product views with a products data.
        /// </summary>
        private void UpdateShelfDisplayView()
        {
            if (m_Products != null && m_ProductViews != null)
            {
                int index = 0;
                foreach (ProductData productData in m_Products)
                {
                    if (index < m_Products.Count)
                    {
                        m_ProductViews[index].Show(productData, m_EditProductViewPopup);
                        index++;
                    }
                }
            }
        }
        
        /// <summary>
        /// This method will hide all the ProdcutViews from the 3D shelf.
        /// </summary>
        private void HideProductViews()
        {
            foreach (ProductView productView in m_ProductViews)
            {
                productView.Hide();
            }
        }
    }
}