using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ShelfDisplay
{
    /// <summary>
    /// This class is responsible to present the product data as view on the screen.
    /// </summary>
    public class ProductView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro m_ProductName;
        [SerializeField] private TextMeshPro m_ProductDescription;
        [SerializeField] private TextMeshPro m_ProductPrice;
        [SerializeField] private Button m_OpenEditorPopupButton;
        
        // A reference to the popup that will allow to make changes to this ProductView data.
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
        
        /// <summary>
        /// Assign an action for the OnClick event for the edit button. 
        /// </summary>
        /// <param name="onClickAction"></param>
        private void SetEditButtonAction(UnityAction onClickAction)
        {
            if(m_OpenEditorPopupButton == null) return;
            
            m_OpenEditorPopupButton.onClick.RemoveAllListeners();
            m_OpenEditorPopupButton.onClick.AddListener(onClickAction);
        }
        
        /// <summary>
        /// Update the product view with the ProductData data.
        /// </summary>
        /// <param name="data"></param>
        private void UpdateProductViewWithData(ProductData data)
        {
            m_ProductName.text = data.name;
            m_ProductDescription.text = data.description;
            m_ProductPrice.text = string.Format("{0:N2}", data.price);
        }
        
        /// <summary>
        /// Clear ProductView data.
        /// </summary>
        private void ClearProductViewData()
        {
            m_ProductName.text = "";
            m_ProductDescription.text = "";
            m_ProductPrice.text = "";
        }
    }
}