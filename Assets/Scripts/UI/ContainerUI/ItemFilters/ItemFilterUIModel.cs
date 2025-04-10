using ItemSystem;
using UniRx;

namespace UI
{
    public class ItemFilterUIModel : UIModel
    {
        public ItemFilterUIModel(EContainerFilter filterType)
        {
            FilterType.Value = filterType;
        }

        public ReactiveProperty<EContainerFilter> FilterType { get; } = new ReactiveProperty<EContainerFilter>();
        public ReactiveProperty<bool> IsSelected { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> HasItemsOfThisType { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<EContainerFilter> SelectedFilter { get; set; }
    }
}
