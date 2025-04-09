using UI.ReactiveViews;
using UniRx;
using UnityEngine;

namespace UI
{
    public class ItemFiltersList : UIReactiveList<ItemFilterView, ItemFilterUIModel>
    {
        protected override void OnSetModel(ReactiveCollection<ItemFilterUIModel> viewModel)
        {
            base.OnSetModel(viewModel);

            Debug.Log($"ItemFiltersList OnSetModel; viewModel = {viewModel}");

        }
    }
}







