using InteractionSystem;
using Player;
using UnityEngine;

namespace ContainerSystem
{
    public class ContainerView : MonoBehaviour, IContainerView, IInteractable
    {
        [field: SerializeField] public string UniqueID { get; private set; }
        [field: SerializeField] public EContainerType ContainerType { get; private set; }

        protected ContainerModel containerModel;

        // IInteractable

        public void Interact(PlayerInteractionPresenter playerInteractionPresenter)
        {
            ContainerOpenData openData = new ContainerOpenData(UniqueID, ContainerType);

            containerModel.TryOpen.OnNext(openData);
        }

        public virtual void OnInteractionCompleted()
        {
            Debug.Log("OnInteractionCompleted");
        }

        // IContainerView

        public bool TryGetUniqueID(out string uniqueID)
        {
            uniqueID = UniqueID;
            return !string.IsNullOrEmpty(uniqueID);
        }

        public void SetContainerModel(ContainerModel model) => containerModel = model;
    }

    internal interface IContainerView
    {
        public bool TryGetUniqueID(out string UniqueID);
        public void SetContainerModel(ContainerModel model);
    }
}