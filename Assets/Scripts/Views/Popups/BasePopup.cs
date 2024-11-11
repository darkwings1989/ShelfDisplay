using TMPro;
using UnityEngine;

namespace ShelfDisplay
{
    /// <summary>
    /// A base popup class for every popup in this app.
    /// </summary>
    public abstract class BasePopup : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI m_Title;
        [SerializeField] protected TextMeshProUGUI m_Description;
        
        /// <summary>
        /// Showing the popup.
        /// Made it virtual if a popup have a specific implementation.
        /// </summary>
        public virtual void ShowPopup()
        {
            gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Removing/hiding the popup.
        /// Made it virtual if a popup have a specific implementation.
        /// </summary>
        public virtual void RemovePopup()
        {
            gameObject.SetActive(false);
        }
    }
}