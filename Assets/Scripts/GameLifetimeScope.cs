using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    //[SerializeField] private ContainerView barrelView;

    //protected override void Configure(IContainerBuilder builder)
    //{
    //    // Регистрация моделей бочек
    //    builder.Register<FoodBarrelModel>(Lifetime.Singleton);
    //    // ... другие бочки

    //    // Регистрация презентера
    //    builder.RegisterBuildCallback(container =>
    //    {
    //        var model = container.Resolve<FoodBarrelModel>();
    //        var presenter = new ContainerPresenter(model, barrelView);
    //        container.Inject(presenter);
    //    });
    //}

    protected override void Configure(IContainerBuilder builder)
    {
    }
}
