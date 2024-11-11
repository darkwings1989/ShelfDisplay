using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ShelfDisplay
{
    /// <summary>
    /// This class is responsible to handle the view and view functionality of the product data edits.
    /// </summary>
    public class EditProductViewPopup : BasePopup
    {
        // The user use this field to change the product name.
        [SerializeField] private TMP_InputField m_NameField;
        
        // The user use this field to change the product price.
        [SerializeField] private TMP_InputField m_PriceField;
        
        // This button will be responsible to apply user changes for the product data. 
        [SerializeField] private Button m_OKButton;
        // This button will be responsible to close this popup without applying any changes. 
        [SerializeField] private Button m_CancelButton;
        [SerializeField] private ConfirmationPopup m_ConfirmationPopup;
        
        // A reference to the ProductView that being currently edit. 
        private ProductView m_ProductView;
        
        // Saving reference to the last selected field for the touch keyboard to know which field ask for new input.
        private TMP_InputField m_SelectedField;
        // Reference to the touch keyboard.
        private TouchScreenKeyboard m_TouchScreenKeyboard;
        
        private void Start()
        {
            // Initial setup for the input fields.
            SetupInputFieldsOnSelectListener();
        }
        
        private void Update()
        {
            // Save changes to the input field from the keyboard value that the user enter.
            if (m_TouchScreenKeyboard != null && m_TouchScreenKeyboard.active)
            {
                m_SelectedField.text = m_TouchScreenKeyboard.text;
            }
        }
        
        /// <summary>
        /// This method will setup the initial data that comes from the ProductView that asked for an edit.
        /// </summary>
        /// <param name="productView"></param>
        public void SetupPopup(ProductView productView)
        {
            // Assign reference to the ProductView that will be edit with this popup help.
            m_ProductView = productView;
            
            // Setup the fields that will be updated.
            m_Title.text = m_ProductView.GetName();
            m_NameField.text = m_ProductView.GetName();
            m_PriceField.text = m_ProductView.GetPrice();
            
            // Setup the buttons with their methods.
            m_OKButton.onClick.AddListener(ApplyChangesToProductViewButton);
            m_CancelButton.onClick.AddListener(CancelEditProductView);
        }
        
        // Private methods.
        
        /// <summary>
        /// This method will apply all user changes to current ProductView that being edit.
        /// </summary>
        private void ApplyChangesToProductViewButton()
        {
            // The new price that will be fetch from user input.
            float newPriceFloat;
            
            // Indication for the changes.
            // If changes applied successfully than this popup will be hide, if not then the user need to fix the issues
            // that occured and apply again.
            bool changesApplied = false;
            
            // Trying to parse string to get a float (doing it first to know if I should continue with applying the changes).
            if (float.TryParse(m_PriceField.text, out newPriceFloat))
            {
                // Applying the changes to the ProductView data.
                m_ProductView.SetName(m_NameField.text);
                m_ProductView.SetPrice(newPriceFloat);
                
                // Showing the user a message that the changes updated successfully.
                m_ConfirmationPopup.SetupPopup("Product name and price updated successfully!");
                changesApplied = true;
            }
            else
            {
                // Default price.
                newPriceFloat = 0.0f;
                m_ConfirmationPopup.SetupPopup("Product price have to be a decimal number, please try again!");
            }
            
            m_ConfirmationPopup.ShowPopup();
            
            // If the changes applied successfully than the popup can be removed(hide).
            if (changesApplied)
            {
                RemovePopup();
            }
        }
        
        /// <summary>
        /// This method cancel the edit and not applying any changes to the ProductView data.
        /// </summary>
        private void CancelEditProductView()
        {
            // Clearing the popup for the next time.
            ClearPopup();
            RemovePopup();
        }
        
        /// <summary>
        /// Clearing the popup data.
        /// </summary>
        private void ClearPopup()
        {
            m_ProductView = null;
            m_NameField.text = "";
            m_PriceField.text = "";
            m_OKButton.onClick.RemoveAllListeners();
            m_CancelButton.onClick.RemoveAllListeners();
        }
        
        /// <summary>
        /// This method make sure that a selected input field will force the touch keyboard being focuse on mobile devices.
        /// </summary>
        private void SetupInputFieldsOnSelectListener()
        {
            // Force keyboard open on field selection.
            m_NameField.onSelect.AddListener(delegate
            {
                ForceVirtualKeyboardOnMobileToOpen();
                m_SelectedField = m_NameField;
            });
            
            m_PriceField.onSelect.AddListener(delegate
            {
                ForceVirtualKeyboardOnMobileToOpen();
                m_SelectedField = m_PriceField;
            });
        }
        
        /// <summary>
        /// Force the touch keyboard to show up for mobile devices.
        /// </summary>
        private void ForceVirtualKeyboardOnMobileToOpen()
        {
            if (Application.isMobilePlatform)
            {
                m_TouchScreenKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            }
        }
    }
}