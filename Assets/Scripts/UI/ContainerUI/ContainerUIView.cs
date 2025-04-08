using UI.ReactiveViews;
using UnityEngine;

namespace UI
{
    public class ContainerUIView : UIView
    {
        [SerializeField] private UIView _hintView_EquipMode;
        [SerializeField] private ItemUIViewsList _itemsList;
        [SerializeField] private ContainerSwitchAreaView _containerSwitchArea;
        [SerializeField] private SortingButtonsAreaView _sortingButtonsArea;

        [Header("LOCALIZATION")]
        [SerializeField] private TextMeshProReactiveStringView _takeTF;
        [SerializeField] private TextMeshProReactiveStringView _takeAllTF;
        [SerializeField] private TextMeshProReactiveStringView _equipModeTF;

        public override void OnSetModel(UIModel uiModel)
        {
            base.OnSetModel(uiModel);

            _hintView_EquipMode.OnSetModel(uiModel);

            if (uiModel is ContainerUIModel containerUIModel)
            {
                _itemsList.SetUIModel(containerUIModel.Items);
                _containerSwitchArea.OnSetModel(containerUIModel.ContainerSwitchAreaModel);
                _sortingButtonsArea.OnSetModel(containerUIModel.SortingButtonsAreaModel);

                _takeTF.SetUIModel(containerUIModel.HintText_Take);
                _takeAllTF.SetUIModel(containerUIModel.HintText_TakeAll);
                _equipModeTF.SetUIModel(containerUIModel.HintText_EquipMode);
            }
        }

        internal void ShowContainerUI(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}







