using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ShelfDisplay
{
    /// <summary>
    /// This class is resposiable to present the product data as view on the screen.
    /// </summary>
    public class ProductView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro m_ProductName;
        [SerializeField] private TextMeshPro m_ProductDescription;
        [SerializeField] private TextMeshPro m_ProductPrice;
        [SerializeField] private Button m_OpenEditorPopupButton;
        
        private EditProductViewPopup m_EditProductViewPopup;
        
        /// <summary>
        /// This method showing this view with an updated data.
        /// </summary>
        public void Show(ProductData data, EditProductViewPopup editProductViewPopup)
        {
            UpdateProductViewWithData(data);
            SetEditButtonAction(() =>
            {
                // Setup editor popup for this ProductView.
                m_EditProductViewPopup = editProductViewPopup;
                m_EditProductViewPopup.SetupPopup(this);
                m_EditProductViewPopup.ShowPopup();
            });
            gameObject.SetActive(true);
        }
        
        /// <summary>
        /// This method hide the view and clearing the data.
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
            ClearProductViewData();
        }
        
        // Getters and Setters.
        public string GetName()
        {
            return m_ProductName.text;
        }

        public string GetPrice()
        {
            return m_ProductPrice.text;
        }

        public void SetName(string newName)
        {
            m_ProductName.text = newName;
        }

        public void SetPrice(float newPrice)
        {
            m_ProductPrice.text = string.Format("{0:N2}", newPrice);
        }
        
        // Private Methods.
        private void SetEditButtonAction(UnityAction onClickAction)
        {
            if(m_OpenEditorPopupButton == null) return;
            
            m_OpenEditorPopupButton.onClick.RemoveAllListeners();
            m_OpenEditorPopupButton.onClick.AddListener(onClickAction);
        }
        
        private void UpdateProductViewWithData(ProductData data)
        {
            m_ProductName.text = data.name;
            m_ProductDescription.text = data.description;
            m_ProductPrice.text = string.Format("{0:N2}", data.price);
        }

        private void ClearProductViewData()
        {
            m_ProductName.text = "";
            m_ProductDescription.text = "";
            m_ProductPrice.text = "";
        }
    }
}