using System;
using System.Drawing;
using RSPModel.Interface;

namespace RSPModel
{

    public delegate void FigureChangedHandler(Figure figure, string playerName);
    public delegate void ExitAppHandler();
    public class Player : MarshalByRefObject, IPlayer, IDisposable
    {
        private string _name;
        private int _score;
        public event FigureChangedHandler FigureChanged;
        public event ExitAppHandler ExitApp;
        private Figure _figure;

        public Player(IGame game)
        {
            _figure = Figure.Empty;
            _score = 0;
            Game = game;
        }

        public IGame Game { get; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 12)
                    _name = value;
                else
                    throw new ArgumentOutOfRangeException($"Name is too long");
            }
        }

        public int Number { get; set; }

        public Figure Figure
        {
            get { return _figure; }
            private set
            {
                _figure = value;
                FigureChanged(_figure, Name);
            }
        }

        public Color Color { get; set; }

        public void Move(Figure figure)
        {
            Figure = figure;
            Game.StartGame();
        }

        public void Reset()
        {
            Figure = Figure.Empty;
        }

        public void Win()
        {
            _score += 10;
        }

        public void ResetScore()
        {
            _score = 0;
        }

        public void Exit()
        {
            ExitApp.Invoke();
        }

        public void Dispose()
        {
            Game.Disconnect(this);
        }
    }
}