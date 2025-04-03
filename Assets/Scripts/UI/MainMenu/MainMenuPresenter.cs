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
        [Inject] private readonly CursorModel _cursorModel;

        public void Start()
        {
            _model.IsMainMenuOpen
                .Subscribe(isOpen => OnMainMenuOpen(isOpen))
                .AddTo(_view);

            _menuInputHandler.OnCancelPressed
                .Subscribe(_ => OnCancelPressed())
                .AddTo(_view);
        }

        private void OnMainMenuOpen(bool isOpen)
        {
            _cursorModel.SetCursorState(isOpen);
            _view.SetVisibility(isOpen);
            Time.timeScale = isOpen ? 0 : 1;
        }

        private void OnCancelPressed()
        {
            if (_containerUIModel.IsContainerUIOpen.Value)
                _containerUIModel.SetContainerOpenState(false, null);
            else
                _model.IsMainMenuOpen.Value = !_model.IsMainMenuOpen.Value;
        }
    }
}

