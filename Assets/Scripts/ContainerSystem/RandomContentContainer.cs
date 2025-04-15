namespace ContainerSystem
{
    public class RandomContentContainer : ContainerModel
    {
        public RandomContentContainer(string uniqueID)
        {
            UniqueID = uniqueID;
        }

        public override string UniqueID { get; }
    }
}