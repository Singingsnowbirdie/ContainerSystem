using System;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace UI
{
    public class CursorPresenter : IStartable, IDisposable
    {
        [Inject] private readonly CursorModel _model;

        CompositeDisposable _disposables = new CompositeDisposable();

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public void Start()
        {
            _model.SetCursorState(false);
        }
    }
}

