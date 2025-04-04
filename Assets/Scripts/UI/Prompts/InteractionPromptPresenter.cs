using InteractionSystem;
using Localization;
using Player;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UI
{
    public class InteractionPromptPresenter : IStartable
    {
        [Inject] private readonly InteractionPromptView _view;
        [Inject] private readonly InteractionPromptUIModel _model;

        [Inject] private readonly PlayerInteractionModel _playerInteractionModel;
        [Inject] private readonly LocalizationModel _localizationModel;

        private readonly string _containerPromptKey = "containerPrompt";

        public void Start()
        {
            _view.OnSetModel(_model);

            _playerInteractionModel.CurrentInteractable
                .Subscribe(val => OnCurrentInteractableUpdated(val))
                .AddTo(_view);

            _playerInteractionModel.IsInteracting
                .Subscribe(val => OnInteracting(val))
                .AddTo(_view);
        }

        private void OnInteracting(bool val)
        {
            if (val)
            {
                _model.PromptText.Value = "";
            }
        }

        private void OnCurrentInteractableUpdated(IInteractable val)
        {
            if (val != null)
                _model.PromptText.Value = GetPromptText();
            else
                _model.PromptText.Value = "";
        }

        private string GetPromptText()
        {
            // TODO: Add other types of interactions

            if (_localizationModel.TryGetTranslation(ELocalizationRegion.HUD, _containerPromptKey, out string translation))
            {
                return translation;
            }
            return "";
        }
    }
}
