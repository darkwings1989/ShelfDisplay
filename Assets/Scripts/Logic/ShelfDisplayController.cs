using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShelfDisplay
{
    /// <summary>
    /// 
    /// </summary>
    public class ShelfDisplayController : MonoBehaviour
    {
        [SerializeField] private List<ProductView> m_ProductViews;
        [SerializeField] private EditProductViewPopup m_EditProductViewPopup;
        
        private Dictionary<string, ProductData> m_Products = new Dictionary<string, ProductData>();


        private void Start()
        {
            RefreshProductsAction();
        }

        public async void RefreshProductsAction()
        {
            // Hide all products view before refreshing the shelf.
            HideProductViews();
            
            // Fetch new products from the server.
            if (ServerCommunication.SharedInstance != null)
            {
                ProductsDataStorage productsDataStorage = await ServerCommunication.SharedInstance.GetProducts();
                
                // Clearing the old data before adding the new data.
                m_Products.Clear();
                
                // Update the dictionary for local data storage.
                foreach (ProductData product in productsDataStorage.products)
                {
                    m_Products.Add(product.name, product);
                }
            }
                
            // Update Products shelf view with the products data that was fetched from the server.
            UpdateShelfDisplayView();
        }

        private void UpdateShelfDisplayView()
        {
            if (m_Products != null && m_ProductViews != null)
            {
                int index = 0;
                foreach (ProductData productData in m_Products.Values)
                {
                    if (index < m_Products.Values.Count)
                    {
                        m_ProductViews[index].Show(productData, m_EditProductViewPopup);
                        index++;
                    }
                }
            }
        }

        private void HideProductViews()
        {
            foreach (ProductView productView in m_ProductViews)
            {
                productView.Hide();
            }
        }
    }
}