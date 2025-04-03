namespace ContainerSystem
{
    public class SupplyContainerModel : ContainerModel
    {
        public SupplyContainerModel(string uniqueID)
        {
            UniqueID = uniqueID;
        }

        public override string UniqueID { get; }
    }
}