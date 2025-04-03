using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UI.MainMenu
{
    public class MainMenuPresenter : IStartable
    {
        [Inject] private readonly MainMenuModel _model;
        [Inject] private readonly MainMenuView _view;
        [Inject] private readonly UIInputHandler _menuInputHandler;
        [Inject] private readonly ContainerUIModel _containerUIModel;

        public void Start()
        {
            _model.IsMenuOpen.Subscribe(isOpen =>
            {
                _view.SetVisibility(isOpen);
                Time.timeScale = isOpen ? 0 : 1;
            });

            _menuInputHandler.OnCancelPressed
                .Subscribe(_ => OnCancelPressed())
                .AddTo(_view);
        }

        private void OnCancelPressed()
        {
            if (_containerUIModel.IsContainerUIOpen.Value)
                _containerUIModel.SetContainerOpenState(false, null);
            else
                _model.IsMenuOpen.Value = !_model.IsMenuOpen.Value;
        }
    }
}

