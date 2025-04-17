namespace DataSystem
{
    public abstract class Repository : IRepository
    {
        public abstract void LoadData();
        public abstract void SaveData();
        public abstract void OnTimeToSave();
        public abstract void ResetData();
    }
}

