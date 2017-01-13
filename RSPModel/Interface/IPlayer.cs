namespace RSPModel.Interface
{
    public interface IPlayer
    {
        void Move(Figure figure);
        int Number { get; set; }
        string Name { get; }
        Figure Figure { get; }
        void Win();
        void Reset();
        void ResetScore();
        void Exit();
    }
}