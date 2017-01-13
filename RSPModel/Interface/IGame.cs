namespace RSPModel.Interface
{
    public interface IGame
    {
        bool Connect(IPlayer player);
        bool Disconnect(IPlayer player);
        void StartGame();
    }
}