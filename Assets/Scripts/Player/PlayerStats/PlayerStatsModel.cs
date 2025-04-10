using UniRx;

namespace Player
{
    public class PlayerStatsModel
    {
        public ReactiveProperty<int> MaxPlayerLevel { get; } = new ReactiveProperty<int>(10); 
        public ReactiveProperty<int> CurrentPlayerLevel { get; } = new ReactiveProperty<int>(1); 
    }
}