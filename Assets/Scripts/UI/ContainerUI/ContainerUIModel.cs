using DataSystem;
using UniRx;
using UnityEngine;
using VContainer.Unity;

public class ContainerUIModel
{
    public ISubject<ContainerData> OpenContainerUI { get; } = new Subject<ContainerData>();
}

public class ContainerUIView : MonoBehaviour
{

}

public class ContainerUIPresenter : IStartable
{
    public void Start()
    {
        throw new System.NotImplementedException();
    }
}
