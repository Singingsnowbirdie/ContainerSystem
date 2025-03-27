namespace UI
{
    public class ItemUIModel : UIModel
    {
        public ItemUIModel(bool canBeEquipped)
        {
            CanBeEquipped = canBeEquipped;
        }

        public bool CanBeEquipped { get; internal set; }
    }
}