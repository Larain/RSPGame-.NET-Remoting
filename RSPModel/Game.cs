using System;
using System.Collections.Generic;

namespace RSPModel
{
    public delegate void ShowPlayerHandler(Player player);

    public class Game : MarshalByRefObject
    {
        private bool _gameStatus;
        private List<string> _namesOfPlayers;

        public List<Player> Winners { get; private set; }

        public List<Player> Players { get; set; }

        public event ShowPlayerHandler ShowPlayer;

        public Player ConnectNewPlayer(Player p)
        {
            if (!_gameStatus)
            {
                if (Players == null)
                {
                    Players = new List<Player>();
                    _namesOfPlayers = new List<string>();
                }
                if (!_namesOfPlayers.Contains(p.Name))
                {
                    p.Number = Players.Count;
                    Players.Add(p);
                    _namesOfPlayers.Add(p.Name);
                    OnShowPlayer(p);
                    return p;
                }
                throw new ArgumentException("Player with this name is already in a game");
            }
            throw new EntryPointNotFoundException("Game is in progress. Wait few seconds.");
        }

        public void Disconnect(Player p)
        {
            try
            {
                Players.Remove(p);
                _namesOfPlayers.Remove(p.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Player> StartGame()
        {
            if (Winners != null)
                Winners.Clear();
            if (Players.Count > 1)
            {
                // Waiting for players to make moves;
                var ready = true;
                foreach (var p in Players)
                    if (p.Figure == "")
                        ready = false;
                if (ready)
                {
                    _gameStatus = true;
                    // Getting players figures;
                    var rock = false;
                    var paper = false;
                    var scissors = false;

                    foreach (var p in Players)
                    {
                        if (p.Figure == "rock")
                            rock = true;
                        if (p.Figure == "paper")
                            paper = true;
                        if (p.Figure == "scissors")
                            scissors = true;
                    }

                    // Check if there are any winner;
                    if (IsAnyWinner(rock, paper, scissors))
                    {
                        Winners = GetWinners(rock, paper, scissors, Players);

                        foreach (var p in Winners)
                        {
                            p.Win();
                            OnShowPlayer(p);
                        }
                    }
                    foreach (var p in Players)
                        ClearPlayersFigure();
                }
            }
            _gameStatus = false;
            return Winners;
        }

        public List<Player> GetWinners(bool rock, bool paper, bool scissors, List<Player> participiants)
        {
            var winnersList = new List<Player>();
            if (rock && paper)
                foreach (var p in Players)
                    if (p.Figure == "paper")
                        winnersList.Add(p);
            if (rock && scissors)
                foreach (var p in Players)
                    if (p.Figure == "rock")
                        winnersList.Add(p);
            if (scissors && paper)
                foreach (var p in Players)
                    if (p.Figure == "scissors")
                        winnersList.Add(p);
            return winnersList;
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
            foreach (var p in Players)
            {
                p.ResetPlayer();
                p.Moved = false;
            }
        }

        // згенерувати подію
        public void OnShowPlayer(Player p)
        {
            if (ShowPlayer != null)
                ShowPlayer(p);
        }

        //Оновити (перемалювати) форму усіх гравців
        public void ShowAllPlayers()
        {
            foreach (var p in Players)
                OnShowPlayer(p);
        }
    }
}