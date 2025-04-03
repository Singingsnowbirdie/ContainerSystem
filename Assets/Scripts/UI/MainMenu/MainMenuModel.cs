using UniRx;

namespace UI.MainMenu
{
    public class MainMenuModel
    {
        public ReactiveProperty<bool> IsMenuOpen { get; } = new ReactiveProperty<bool>(false);
    }
}

