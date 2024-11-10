using TMPro;
using UnityEngine;

namespace ShelfDisplay
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BasePopup : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI m_Title;
        [SerializeField] protected TextMeshProUGUI m_Description;

        public void SetupPopup(string description, string title = "Message")
        {
            m_Title.text = title;
            m_Description.text = description;
        }

        public virtual void ShowPopup()
        {
            gameObject.SetActive(true);
        }

        public virtual void RemovePopup()
        {
            gameObject.SetActive(false);
        }
    }
}