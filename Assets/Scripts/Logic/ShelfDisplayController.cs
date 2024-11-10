using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace ShelfDisplay
{
    /// <summary>
    /// 
    /// </summary>
    public class ShelfDisplayController : MonoBehaviour
    {
        [SerializeField] private Button m_RefreshProductsButton;
        [SerializeField] private ShelfDisplayView m_ShelfDisplayView;
        [SerializeField] private GameObject m_ProductViewPrefab;
        
        private Dictionary<string, ProductData> m_Products = new Dictionary<string, ProductData>();


        public async void RefreshProductsAction()
        {
            if (ServerCommunication.SharedInstance != null)
            {
                ProductsDataStorage productsDataStorage = await ServerCommunication.SharedInstance.GetProducts();

                foreach (ProductData product in productsDataStorage.products)
                {
                    m_Products.Add(product.name, product);
                }
            }

            if (m_Products != null)
            {
                // Update Products shelf view.
                UpdateShelfDisplayView();
            }
        }

        private void UpdateShelfDisplayView()
        {
            
        }
    }
}