using System;
using UnityEngine;
using UnityEngine.UI;

namespace TestGrid.Popups
{
    public class PopupMessage : MonoBehaviour
    {
        [SerializeField] private Text _tMessage;
    
        private Action<ModalResult> _closeCallback;
        
        public void Show(string message, Action<ModalResult> closeCallback)
        {
            _closeCallback = closeCallback;
            _tMessage.text = message;
            gameObject.SetActive(true);
        }

        public void Close() //Reflection invokation
        {
            gameObject.SetActive(false);
            _closeCallback?.Invoke(ModalResult.Ok);
        }
    }
}
