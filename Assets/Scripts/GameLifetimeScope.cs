using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    //[SerializeField] private ContainerView barrelView;

    //protected override void Configure(IContainerBuilder builder)
    //{
    //    // ����������� ������� �����
    //    builder.Register<FoodBarrelModel>(Lifetime.Singleton);
    //    // ... ������ �����

    //    // ����������� ����������
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
