using DataSystem;
using ItemSystem;
using System;
using System.Collections.Generic;

namespace ContainerSystem
{
    public class ContainersModel
    {
        private ContainersRepository _containersRepository;
        private ItemDatabase _itemDatabase;

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
}



