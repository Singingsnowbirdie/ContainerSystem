namespace DataSystem
{
    public interface IRepository
    {
        void LoadData();
        void OnTimeToSave();
        void ResetData();
        void SaveData();
    }
}