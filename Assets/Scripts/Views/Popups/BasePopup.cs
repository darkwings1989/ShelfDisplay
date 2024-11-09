using TMPro;
using UnityEngine;

namespace ShelfDisplay
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BasePopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_Title;
        [SerializeField] private TextMeshProUGUI m_Description;

        public void SetupPopup(string title, string description)
        {
            m_Title.text = title;
            m_Description.text = description;
        }

        public abstract void ShowPopup();
        public abstract void RemovePopup();
    }
}