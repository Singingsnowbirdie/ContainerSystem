using DataSystem;
using System.Collections.Generic;
using UnityEngine;

namespace ContainerSystem
{
    public class BookshelfView : ContainerView
    {
        [SerializeField] List<ShelfItem> _shelfItems;

        public override void OnInteractionCompleted()
        {
            base.OnInteractionCompleted();

            ContainerInteractionCompletedData data = new ContainerInteractionCompletedData(containerModel.UniqueID, this);
            containerModel.InteractionCompleted.OnNext(data);
        }

        internal void UpdateShelfItems(ContainerData containerData)
        {
            int currentBooksAmount = GetCurrentBooksAmount(containerData.Items);

            for (int i = 0; i < _shelfItems.Count; i++)
            {
                if (i > currentBooksAmount - 1)
                    _shelfItems[i].ShowItem(false);
                else
                    _shelfItems[i].ShowItem(true);
            }
        }

        private int GetCurrentBooksAmount(List<ItemData> items)
        {
            int amount = 0;

            foreach (ItemData item in items)
            {
                if (item.ItemType == ItemSystem.EItemType.Book)
                    amount++;
            }
            return amount;
        }
    }
}