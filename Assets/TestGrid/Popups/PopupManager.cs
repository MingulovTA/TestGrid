using UnityEngine;
using UnityEngine.UI;

namespace TestGrid.Popups
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private PopupMessage _popupMessage;
        [SerializeField] private Image _bgScreen;
        
        public void ShowMessagePopup(string message)
        {
            _popupMessage.Show(message,CloseHandler);
            _bgScreen.gameObject.SetActive(true);
        }

        private void CloseHandler(ModalResult modalResult)
        {
            _bgScreen.gameObject.SetActive(false);
            //Do something
        }
    }
}
