using UniRx;

namespace ContainerSystem
{
    public abstract class ContainerModel : IContainerModel
    {
        public abstract string UniqueID { get; }
        public ISubject<ContainerOpenData> TryOpen { get; } = new Subject<ContainerOpenData>();
    }

    public readonly struct ContainerOpenData
    {
        public ContainerOpenData(string uniqueID, EContainerType containerType)
        {
            UniqueID = uniqueID;
            ContainerType = containerType;
        }

        public string UniqueID { get; }
        public EContainerType ContainerType { get; }
    }

}