using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using RSPModel.Interface;

namespace RSPModel
{
    public delegate void ShowResultHandler(Dictionary<IPlayer, Color> color);
    public delegate void SendTextHandler(String text);

    public class Game : MarshalByRefObject, IGame, IDisposable
    {
        private int _portCounter;
        private List<IPlayer> _players;
        private List<string> _namesOfPlayers;
        private List<IPlayer> _winners;
        private bool _gameStatus;

        public event ShowResultHandler ShowResult;
        public event SendTextHandler SendText;


        public List<IPlayer> Winners
        {
            get { return _winners ?? (_winners = new List<IPlayer>()); }
        }

        public List<IPlayer> Players
        {
            get { return _players ?? (_players = new List<IPlayer>()); }
        }

        public bool Connect(IPlayer p)
        {
            if (!_gameStatus)
            {
                if (_players == null)
                {
                    _players = new List<IPlayer>();
                    _namesOfPlayers = new List<string>();
                }
                if (!_namesOfPlayers.Contains(p.Name))
                {
                    p.Number = _players.Count;
                    _players.Add(p);
                    _namesOfPlayers.Add(p.Name);
                    LogUserAction(p.Name + " connected");
                    
                    return true;
                }
                throw new ArgumentException("Player with this name is already in a game");
            }
            throw new EntryPointNotFoundException("Game is in progress. Wait few seconds.");
        }

        private void LogUserAction(string text)
        {
            SendText?.Invoke(text + "\n");
        }

        public bool Disconnect(IPlayer p)
        {
            _players.Remove(p);
            _namesOfPlayers.Remove(p.Name);
            return true;
        }

        public void StartGame()
        {
            _winners?.Clear();
            if (_players.Count > 1)
            {
                // Waiting for players to make moves;
                bool ready = true;
                foreach (IPlayer p in _players)
                {
                    LogUserAction(p.Name + " " + p.Figure);
                    if (p.Figure == Figure.Empty)
                        ready = false;
                }
                if (ready)
                {
                    _gameStatus = true;
                    // Getting players figures;
                    bool rock = false;
                    bool paper = false;
                    bool scissors = false;

                    foreach (IPlayer p in _players)
                    {
                        if (p.Figure == Figure.Rock)
                            rock = true;
                        if (p.Figure == Figure.Paper)
                            paper = true;
                        if (p.Figure == Figure.Scissors)
                            scissors = true;
                    }

                    Dictionary<IPlayer, Color> results = new Dictionary<IPlayer, Color>();
                    foreach (IPlayer p in Players)
                    {
                        results.Add(p, Color.Black);
                    }
                    // Check if there are any winner;
                    if (IsAnyWinner(rock, paper, scissors))
                    {
                        _winners = GetWinners(rock, paper, scissors);
                        List<IPlayer> losers = Players.Except(_winners).ToList();
                        
                        foreach (IPlayer p in _winners)
                        {
                            p.Win();
                            results.Remove(p);
                            results.Add(p, Color.SeaGreen);
                        }
                    }
                    foreach (var p in Players)
                    {
                        OnShowPlayer(results);
                    }
                    foreach (IPlayer p in _players)
                        ClearPlayersFigure();
                }
            }
            _gameStatus = false;
        }

        public List<IPlayer> GetWinners(bool rock, bool paper, bool scissors)
        {
            if (_players.Count > 0)
            {
                List<IPlayer> winnersList = new List<IPlayer>();
                if (rock && scissors)
                    foreach (IPlayer p in _players)
                        if (p.Figure == Figure.Rock)
                            winnersList.Add(p);
                if (rock && paper)
                    foreach (IPlayer p in _players)
                        if (p.Figure == Figure.Paper)
                            winnersList.Add(p);
                if (scissors && paper)
                    foreach (IPlayer p in _players)
                        if (p.Figure == Figure.Scissors)
                            winnersList.Add(p);
                return winnersList;
            }
            throw new InvalidOperationException("Not enough players.");
        }

        public bool IsAnyWinner(bool rock, bool paper, bool scissors)
        {
            if (rock && paper && scissors)
                return false;
            if (rock && !paper && !scissors || !rock && !paper && scissors || !rock && paper && !scissors)
                return false;
            return true;
        }

        public void ClearPlayersFigure()
        {
            foreach (IPlayer p in _players)
                p.Reset();
        }

        public void OnShowPlayer(Dictionary<IPlayer, Color> color)
        {
            ShowResult?.Invoke(color);
        }

        public int GetPortForPlayer()
        {
            int port = 8901 + _portCounter++;
            LogUserAction(port.ToString() + " Is Opened!");
            return port;
        }

        public void Dispose()
        {
            foreach (var player in Players)
            {
                player.Exit();
            }
        }
    }
}
