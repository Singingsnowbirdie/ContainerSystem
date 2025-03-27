using DataSystem;
using System.Collections.Generic;

namespace ContainerSystem
{
    public class ContainersModel
    {
        public Dictionary<string, ContainerView> ContainerViews { get; private set; } = new Dictionary<string, ContainerView>();
        public Dictionary<string, ContainerModel> ContainerModels { get; private set; } = new Dictionary<string, ContainerModel>();

        private ContainersRepository _containersRepository;

        public ContainersRepository ContainersRepository
        {
            get
            {
                _containersRepository ??= new ContainersRepository();
                return _containersRepository;
            }
        }
    }
}



