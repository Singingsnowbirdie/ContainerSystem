using System;
using UI.MainMenu;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace UI
{
    public class CursorPresenter : IStartable, IDisposable
    {
        [Inject] private readonly CursorModel _model;
        [Inject] private readonly MainMenuUIModel _mainMenuUIModel;
        [Inject] private readonly ContainerUIModel _containerUIModel;

        CompositeDisposable _disposables = new CompositeDisposable();

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public void Start()
        {
            _mainMenuUIModel.IsMainMenuOpen
                .Subscribe(isOpen => OnSomeUIOpen(isOpen))
                .AddTo(_disposables);

            _containerUIModel.IsContainerUIOpen
                .Subscribe(isOpen => OnSomeUIOpen(isOpen))
                .AddTo(_disposables);

            _model.SetCursorState(false);
        }

        private void OnSomeUIOpen(bool isOpen)
        {
            _model.SetCursorState(isOpen);
        }
    }
}

