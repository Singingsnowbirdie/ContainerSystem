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
        public ISubject<SelectFilterData> SelectFilter { get; } = new Subject<SelectFilterData>();
        public ReactiveProperty<EContainerFilter> SelectedFilter { get; set; }
    }

    public readonly struct SelectFilterData
    {
        public SelectFilterData(EContainerFilter filterType)
        {
            FilterType = filterType;
        }

        public EContainerFilter FilterType { get; }
    }
}







