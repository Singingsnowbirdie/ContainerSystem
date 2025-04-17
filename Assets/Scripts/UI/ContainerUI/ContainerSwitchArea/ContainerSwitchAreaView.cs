using System;
using TMPro;
using UI.ReactiveViews;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ContainerSwitchAreaView : UIView, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("ICONS")]
        [SerializeField] private Image _containerIcon;
        [SerializeField] private Image _inventoryIcon;
        [SerializeField] private ContainerActionIconView _switcherActionIcon;

        [Header("REACTIVE TEXT")]
        [SerializeField] private TextMeshProReactiveStringView _containerNameTF;
        [SerializeField] private TextMeshProReactiveStringView _inventoryNameTF;

        [Header("TMP")]
        [SerializeField] private TMP_Text _containerNameTMP;
        [SerializeField] private TMP_Text _inventoryNameTMP;

        [Header("BUTTON")]
        [SerializeField] private Button _switchButton;

        private readonly Color _activeColor = Color.white;
        private readonly Color _inactiveColor = new(0.5f, 0.5f, 0.5f);

        private ContainerSwitchAreaModel _switchAreaModel;

        public override void OnSetModel(UIModel uiModel)
        {
            base.OnSetModel(uiModel);

            if (uiModel is ContainerSwitchAreaModel switchAreaModel)
            {
                _switchAreaModel = switchAreaModel;

                _switcherActionIcon.SetUIModel(_switchAreaModel.SwitcherActionIcon);

                _containerNameTF.SetUIModel(_switchAreaModel.ContainerName);
                _inventoryNameTF.SetUIModel(_switchAreaModel.InventoryName);

                _switchAreaModel.IsInventoryShown
                    .Subscribe(val => OnInventoryShown(val))
                    .AddTo(this);

                _switchAreaModel.IsHovered
                    .Subscribe(val => OnHovered(val, _switchAreaModel.IsInventoryShown.Value))
                    .AddTo(this);

                _switchButton.OnClickAsObservable()
                    .Subscribe(_ => OnSwitch())
                    .AddTo(this);
            }
        }

        private void OnSwitch()
        {
            _switchAreaModel.IsInventoryShown.Value = !_switchAreaModel.IsInventoryShown.Value;
        }

        private void OnHovered(bool isHovered, bool isInventoryShown)
        {
            bool highlightContainer = (!isInventoryShown && !isHovered) || (isInventoryShown && isHovered);

            Color containerColor = highlightContainer ? _activeColor : _inactiveColor;
            Color inventoryColor = highlightContainer ? _inactiveColor : _activeColor;

            _containerNameTMP.color = containerColor;
            _inventoryNameTMP.color = inventoryColor;
            _containerIcon.color = containerColor;
            _inventoryIcon.color = inventoryColor;
        }

        private void OnInventoryShown(bool isInventoryShown)
        {
            Color containerColor = isInventoryShown ? _inactiveColor : _activeColor;
            Color inventoryColor = isInventoryShown ? _activeColor : _inactiveColor;

            _containerNameTMP.color = containerColor;
            _inventoryNameTMP.color = inventoryColor;
            _containerIcon.color = containerColor;
            _inventoryIcon.color = inventoryColor;

            _switchAreaModel.SwitcherActionIcon.Value = isInventoryShown
                ? ItemSystem.EContainerAction.ContainerContantShown
                : ItemSystem.EContainerAction.InventoryContantShown;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _switchAreaModel.IsHovered.Value = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _switchAreaModel.IsHovered.Value = false;
        }
    }
}







