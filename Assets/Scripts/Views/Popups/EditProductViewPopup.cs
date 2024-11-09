using UnityEngine;
using UnityEngine.UI;

namespace ShelfDisplay
{
    /// <summary>
    /// 
    /// </summary>
    public class EditProductViewPopup : BasePopup
    {
        [SerializeField] private InputField m_NameField;
        [SerializeField] private InputField m_PriceField;
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