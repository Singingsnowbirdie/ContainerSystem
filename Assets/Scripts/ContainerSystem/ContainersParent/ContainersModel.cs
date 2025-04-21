using DataSystem;
using ItemSystem;
using System;
using System.Collections.Generic;
using UniRx;

namespace ContainerSystem
{
    public class ContainersModel
    {
        private ContainersRepository _containersRepository;
        private ItemDatabase _itemDatabase;

        public ISubject<AddItemToContainerData> AddItem { get; } = new Subject<AddItemToContainerData>();

        public Dictionary<string, ContainerView> ContainerViews { get; private set; } = new Dictionary<string, ContainerView>();
        public Dictionary<string, ContainerModel> ContainerModels { get; private set; } = new Dictionary<string, ContainerModel>();

        public ItemDatabase ItemDatabase
        {
            get
            {
                _itemDatabase ??= new ItemDatabase();
                return _itemDatabase;
            }
        }

        public ContainersRepository ContainersRepository
        {
            get
            {
                _containersRepository ??= new ContainersRepository();
                return _containersRepository;
            }
        }

        internal void TimeToSave()
        {
            throw new NotImplementedException();
        }
    }

    public readonly struct AddItemToContainerData
    {
        public AddItemToContainerData(string containerID, string itemConfigKey, int amountToAdd) : this()
        {
            ContainerID = containerID;
            ItemConfigKey = itemConfigKey;
            AmountToAdd = amountToAdd;
        }

        public int AmountToAdd { get; }
        public string ContainerID { get; }
        public string ItemConfigKey { get; }
    }

}



