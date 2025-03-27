using DataSystem;
using UI;
using UniRx;

public class ContainerUIModel: UIModel
{
    public ISubject<ContainerData> OpenContainerUI { get; } = new Subject<ContainerData>();
}
