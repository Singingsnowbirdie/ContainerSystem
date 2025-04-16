using UI.ReactiveViews;
using UniRx;

namespace UI
{
    public class ItemFiltersList : UIReactiveList<ItemFilterView, ItemFilterUIModel>
    {
        protected override void OnSetModel(ReactiveCollection<ItemFilterUIModel> viewModel)
        {
            base.OnSetModel(viewModel);
        }
    }
}







