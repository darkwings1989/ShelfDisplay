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
        [SerializeField, Tooltip("The ProductViews that will show the product data from the sever.")] 
        private List<ProductView> m_ProductViews;
        
        [SerializeField, Tooltip("The popup that will allow to make changes to a ProductView data.")] 
        private EditProductViewPopup m_EditProductViewPopup;
        
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

            if (m_Products == null)
            {
                // TODO: In the future I can show this message to the user.
                Debug.LogError("App failed to get products from the server!");
                return;
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
                for (int i = 0; i < m_Products.Count; i++)
                {
                    ProductData productData = m_Products[i];
                    m_ProductViews[i].Show(productData, m_EditProductViewPopup);
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