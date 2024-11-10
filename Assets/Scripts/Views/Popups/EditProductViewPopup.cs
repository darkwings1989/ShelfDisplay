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
        
        public override void ShowPopup()
        {
            throw new System.NotImplementedException();
        }

        public override void RemovePopup()
        {
            throw new System.NotImplementedException();
        }
    }
}