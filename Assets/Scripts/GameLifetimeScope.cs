using ContainerSystem;
using InventorySystem;
using Localization;
using Player;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [Header("UI")]
    [SerializeField] private InteractionPromptView _interactionPromptView;
    [SerializeField] private ContainerUIView _containerUIView;
    [SerializeField] private LocalizationUIView _localizationUIView;

    [Header("PLAYER")]
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private PlayerInput _playerInput;

    [Header("CAMERA")]
    [SerializeField] private Camera _camera;

    [Header("CONTAINERS")]
    [SerializeField] private ContainersView _containersView;

    protected override void Configure(IContainerBuilder builder)
    {
        // Register Views
        builder.RegisterComponent(_playerView).AsSelf();
        builder.RegisterComponent(_containersView).AsSelf();

        // Register UI Views
        builder.RegisterComponent(_interactionPromptView).AsSelf();
        builder.RegisterComponent(_containerUIView).AsSelf();
        builder.RegisterComponent(_localizationUIView).AsSelf();

        // Register Other Components
        builder.RegisterComponent(_playerInput).AsSelf();
        builder.RegisterComponent(_camera).AsSelf();

        // Register Models
        builder.Register<PlayerLocomotionModel>(Lifetime.Singleton);
        builder.Register<PlayerInteractionModel>(Lifetime.Singleton);
        builder.Register<InventoryModel>(Lifetime.Singleton);
        builder.Register<CursorModel>(Lifetime.Singleton);
        builder.Register<ContainersModel>(Lifetime.Singleton);
        builder.Register<LocalizationModel>(Lifetime.Singleton);

        // Register UI Models
        builder.Register<InteractionPromptUIModel>(Lifetime.Singleton);
        builder.Register<ContainerUIModel>(Lifetime.Singleton);

        // Register Presenters
        builder.RegisterEntryPoint<PlayerPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<PlayerLocomotionPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<PlayerInteractionPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<InventoryPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<CursorPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<ContainersPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<LocalizationPresenter>(Lifetime.Singleton);

        // Register UI Presenters
        builder.RegisterEntryPoint<InteractionPromptPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<ContainerUIPresenter>(Lifetime.Singleton);
    }
}
