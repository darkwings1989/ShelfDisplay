
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShelfDisplay
{
    /// <summary>
    /// Confirmation popup for the user to get a feedback after making updates to the ProdcutView data.
    /// </summary>
    public class ConfirmationPopup : BasePopup
    {
        [SerializeField] private Button m_OkButton;
        
        /// <summary>
        /// Setting up the popup with updated data to be ready before showing to the user.
        /// Made it virtual if a popup have a specific implementation.
        /// </summary>
        /// <param name="description">Popup description (not every popup will have a description) </param>
        /// <param name="title">Popup title</param>
        public void SetupPopup(string description, string title = "Message")
        {
            m_Title.text = title;
            m_Description.text = description;
        }
        
        private void Awake()
        {
            // Assign a listener to the OK button.
            if (m_OkButton != null)
            {
                m_OkButton.onClick.AddListener(() =>
                {
                    RemovePopup();
                });
            }
        }
    }
}
