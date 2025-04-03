using DataSystem;
using UniRx;

namespace UI
{
    public class ContainerUIModel : UIModel
    {
        public ISubject<ContainerData> OpenContainerUI { get; } = new Subject<ContainerData>();
        public ReactiveProperty<ItemUIView> SelectedItem { get; } = new ReactiveProperty<ItemUIView>();
        public ReactiveCollection<ItemUIModel> Items { get; } = new ReactiveCollection<ItemUIModel>();
        public ReactiveProperty<bool> IsContainerUIOpen { get; } = new ReactiveProperty<bool>(false);

        public void SetContainerOpenState(bool isOpen, ContainerData data = null)
        {
            IsContainerUIOpen.Value = isOpen;
            if (isOpen && data != null)
            {
                OpenContainerUI.OnNext(data);
            }
        }
    }
}

