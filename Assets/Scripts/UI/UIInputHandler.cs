using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace UI.MainMenu
{
    public class UIInputHandler : MonoBehaviour
    {
        [Inject] private readonly PlayerInput _playerInput;

        public Subject<Unit> OnCancelPressed { get; } = new Subject<Unit>();

        private void Start()
        {
            Observable.EveryUpdate()
                .Where(_ => _playerInput.actions["Cancel"].WasPressedThisFrame())
                .Subscribe(_ => OnCancelPressed.OnNext(Unit.Default))
                .AddTo(this);
        }
    }
}

