using System;
using UniRx;
using VContainer.Unity;

namespace Player
{
    public class PlayerPresenter : IStartable, IDisposable
    {

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public void Start()
        {

        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}


