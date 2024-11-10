using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ShelfDisplay
{
    /// <summary>
    /// 
    /// </summary>
    public class EditProductViewPopup : BasePopup
    {
        [SerializeField] private TMP_InputField m_NameField;
        [SerializeField] private TMP_InputField m_PriceField;
        [SerializeField] private Button m_OKButton;
        [SerializeField] private Button m_CancelButton;
        [SerializeField] private ConfirmationPopup m_ConfirmationPopup;

        private ProductView m_ProductView;

        public void SetupPopup(ProductView productView)
        {
            // Assign reference to the ProductView that will be edit with this popup help.
            m_ProductView = productView;
            
            //Setup the fields that will be updated.
            m_Title.text = m_ProductView.GetName();
            m_NameField.text = m_ProductView.GetName();
            m_PriceField.text = m_ProductView.GetPrice();
            
            m_OKButton.onClick.AddListener(ApplyChangesToProductViewButton);
            m_CancelButton.onClick.AddListener(CancelEditProductView);
        }

        private void ApplyChangesToProductViewButton()
        {
            float newPriceFloat;
            bool changesApplied = false;
            
            if (float.TryParse(m_PriceField.text, out newPriceFloat))
            {
                m_ProductView.SetName(m_NameField.text);
                m_ProductView.SetPrice(newPriceFloat);
                
                m_ConfirmationPopup.SetupPopup("Product name and price updated successfully!");
                changesApplied = true;
            }
            else
            {
                newPriceFloat = 0.0f;
                m_ConfirmationPopup.SetupPopup("Product price have to be a decimal number, please try again!");
            }
            
            m_ConfirmationPopup.ShowPopup();

            if (changesApplied)
            {
                RemovePopup();
            }
        }

        private void CancelEditProductView()
        {
            ClearPopup();
            RemovePopup();
        }

        private void ClearPopup()
        {
            m_ProductView = null;
            m_NameField.text = "";
            m_PriceField.text = "";
            m_OKButton.onClick.RemoveAllListeners();
            m_CancelButton.onClick.RemoveAllListeners();
        }
    }
}