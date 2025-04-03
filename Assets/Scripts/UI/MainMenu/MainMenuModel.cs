using UniRx;

namespace UI.MainMenu
{
    public class MainMenuModel
    {
        public ReactiveProperty<bool> IsMainMenuOpen { get; } = new ReactiveProperty<bool>(false);
    }
}

