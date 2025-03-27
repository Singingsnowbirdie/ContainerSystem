using DataSystem;
using UniRx;

namespace UI
{
    public class ContainerUIModel : UIModel
    {
        public ISubject<ContainerData> OpenContainerUI { get; } = new Subject<ContainerData>();
        public ReactiveProperty<ItemUIView> SelectedItem { get; } = new ReactiveProperty<ItemUIView>();
    }

}

