
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShelfDisplay
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfirmationPopup : BasePopup
    {
        [SerializeField] private Button m_OkButton;

        private void Awake()
        {
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
