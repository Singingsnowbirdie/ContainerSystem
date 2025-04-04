using Localization;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UI.MainMenu
{
    public class MainMenuPresenter : IStartable
    {
        [Inject] private readonly MainMenuUIModel _model;
        [Inject] private readonly MainMenuUIView _view;

        [Inject] private readonly UIInputHandler _menuInputHandler;
        [Inject] private readonly ContainerUIModel _containerUIModel;
        [Inject] private readonly CursorModel _cursorModel;
        [Inject] private readonly LocalizationModel _localizationModel;

        private readonly string _localizationSettingsTextKey = "settings_localization";

        public void Start()
        {
            _model.IsMainMenuOpen
                .Subscribe(isOpen => OnMainMenuOpen(isOpen))
                .AddTo(_view);

            _menuInputHandler.OnCancelPressed
                .Subscribe(_ => OnCancelPressed())
                .AddTo(_view);

            _localizationModel.CurrentLanguage
                .Subscribe(_ => OnCurrentLanguageUpdated())
                .AddTo(_view);

            _view.OnSetModel(_model);
        }

        private void OnCurrentLanguageUpdated()
        {
            if (_localizationModel.TryGetTranslation(ELocalizationRegion.MainMenu, _localizationSettingsTextKey, out string translation))
            {
                _model.LocalizationSettingsText.Value = translation;
            }
            else
            {
                _model.LocalizationSettingsText.Value = "translation missed";
            }
        }

        private void OnMainMenuOpen(bool isOpen)
        {
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

