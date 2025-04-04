using UI.ReactiveViews;
using UnityEngine;

namespace UI.MainMenu
{
    public class MainMenuUIView : UIView
    {
        [field: SerializeField] public TextMeshProReactiveStringView LocalizationSettingsTF { get; private set; }

        public override void OnSetModel(UIModel uiModel)
        {
            MainMenuUIModel model = (MainMenuUIModel)uiModel;
            LocalizationSettingsTF.SetUIModel(model.LocalizationSettingsText);
        }

        public void SetVisibility(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}
