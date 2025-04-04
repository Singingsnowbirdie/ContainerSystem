using UniRx;

namespace UI.MainMenu
{
    public class MainMenuUIModel : UIModel
    {
        public ReactiveProperty<bool> IsMainMenuOpen { get; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<string> LocalizationSettingsText { get; } = new ReactiveProperty<string>();
    }
}

