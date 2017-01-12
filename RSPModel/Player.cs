using System;
using System.Drawing;

namespace RSPModel
{
    public class Player : MarshalByRefObject
    {
        private readonly Game _game;
        private string _name;
        private int _score;

        public Player(string name, Color color, Game game)
        {
            _name = name;
            Color = color;
            _score = 0;
            _game = game;
            Moved = false;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name.Length < 12)
                    _name = value;
                else
                    throw new ArgumentOutOfRangeException($"Name is too long");
            }
        }

        public int Number { get; set; }

        public bool Moved { get; set; }

        public string Figure { get; private set; }

        public Color Color { get; set; }

        public void MakeMove(string input)
        {
            if (input == "rock" || input == "paper" || input == "scissors")
            {
                Figure = input;
                Moved = true;
                _game.StartGame();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Wrong figure name");
            }
        }

        public void ResetPlayer()
        {
            Figure = "";
        }

        public void Win()
        {
            _score += 10;
        }

        public void ResetScore()
        {
            _score = 0;
        }
    }
}