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

        private Button m_OpenProductDataEditorPopup;
        
        /// <summary>
        /// This method showing this view with an updated data.
        /// </summary>
        public void Show(ProductData data, UnityAction onClickAction)
        {
            UpdateProductViewWithData(data);
            SetEditButtonAction(onClickAction);
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

        private void SetEditButtonAction(UnityAction onClickAction)
        {
            if(m_OpenProductDataEditorPopup == null) return;
            
            m_OpenProductDataEditorPopup.onClick.RemoveAllListeners();
            m_OpenProductDataEditorPopup.onClick.AddListener(onClickAction);
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