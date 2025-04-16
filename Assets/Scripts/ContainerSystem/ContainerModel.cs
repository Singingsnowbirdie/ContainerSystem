using UniRx;

namespace ContainerSystem
{
    public class ContainerModel
    {
        public ContainerModel(string uniqueID)
        {
            UniqueID = uniqueID;
        }

        public string UniqueID { get; private set; }
        public ISubject<ContainerOpenData> TryOpen { get; } = new Subject<ContainerOpenData>();
        public ISubject<ContainerInteractionCompletedData> InteractionCompleted { get; } = new Subject<ContainerInteractionCompletedData>();
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

    public readonly struct ContainerInteractionCompletedData
    {
        public ContainerInteractionCompletedData(string uniqueID, BookshelfView shelfView)
        {
            UniqueID = uniqueID;
            ShelfView = shelfView;
        }

        public string UniqueID { get; }
        public BookshelfView ShelfView { get; }
    }

}