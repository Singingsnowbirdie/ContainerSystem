using UnityEngine;

namespace UI.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        public void SetVisibility(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}

