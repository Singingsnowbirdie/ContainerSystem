using InteractionSystem;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Player
{
    public class PlayerInteractionPresenter : IStartable, IDisposable, ITickable
    {
        [Inject] private readonly PlayerInteractionModel _model;
        [Inject] private readonly PlayerInput _playerInput;
        [Inject] private readonly Camera _camera;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private readonly float _interactionDistance = 3f;

        public void Start()
        {
            _playerInput.actions["Interact"].started += OnTryInteract;
        }

        private void OnTryInteract(InputAction.CallbackContext context)
        {
            if (_model.CurrentInteractable.Value != null)
            {
                Interact(_model.CurrentInteractable.Value);
            }
        }

        private void DetectInteractable()
        {
            if (_model.IsInteracting.Value)
                return;

            Ray ray = new(_camera.transform.position, _camera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, _interactionDistance) &&
                hit.collider.TryGetComponent(out IInteractable interactable))
            {
                if (_model.CurrentInteractable.Value != interactable)
                {
                    _model.CurrentInteractable.Value = interactable;
                    return;
                }
            }
            else
                _model.CurrentInteractable.Value = null;
        }

        private void Interact(IInteractable interactable)
        {
            interactable.Interact(this);
            _model.IsInteracting.Value = true;
        }

        internal void OnInteractionCompleted()
        {
            _model.IsInteracting.Value = false;
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }

        public void Tick()
        {
            DetectInteractable();
        }
    }
}