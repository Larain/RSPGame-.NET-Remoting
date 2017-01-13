using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using System.Windows.Forms;
using RSPModel;
using RSPModel.Interface;

namespace RSPClient
{
    public delegate void ShowPlayerHandler(Player player);

    public partial class ClientForm : Form
    {
        private Game _game;
        private Player _player;
        private int _port;

        public ClientForm()
        {
            InitializeComponent();
        }

        #region Client - Server

        public void StartServer()
        {
            var sPort = 8900;
            ChannelServices.RegisterChannel(CreateChannel(sPort), false);
            
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Game), "GameObject", WellKnownObjectMode.Singleton);

            this.Text = "Running as Server. Port: " + sPort;
            rtbServerOutput.Visible = true;
            //rtbServerOutput.Enabled = false;
            rtbServerOutput.ForeColor = Color.Azure;
            rtbServerOutput.BackColor = Color.Black;

            this.BackColor = Color.SteelBlue;
            btEnterName.Visible = false;
            btChoose.Visible = false;
            closeClientsToolStripMenuItem.Visible = true;

            _game = (Game)Activator.GetObject(typeof(Game), "tcp://localhost:8900/GameObject");
            _port = _game.GetPortForPlayer();
            ChannelServices.RegisterChannel(CreateChannel(_port), false);

            _game.SendText += ServerConsoleLog;
        }

        public void ConnectToServer()
        {
            // Створити та зареєструвати канал для взаємодії з сервером
            //ChannelServices.RegisterChannel(CreateChannel(8901), false);
            // Отримати посилання на віддалений об'ект-гру
            try
            {
                _game = (Game)Activator.GetObject(typeof(Game), "tcp://localhost:8900/GameObject");
                _port = _game.GetPortForPlayer();
                ChannelServices.RegisterChannel(CreateChannel(_port), false);

                _game.ShowResult += PrintResult;

                _player = new Player(_game);
                _player.FigureChanged += PlayerOnFigureChanged;
                _player.ExitApp += PlayerOnExitApp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private TcpChannel CreateChannel(int port)
        {
            var sp = new BinaryServerFormatterSinkProvider();
            var cp = new BinaryClientFormatterSinkProvider();

            sp.TypeFilterLevel = TypeFilterLevel.Full; // Allow delegate transfer

            IDictionary propertiesDictionary = new Hashtable();
            propertiesDictionary["port"] = port;
            propertiesDictionary["typeFilterLevel"] = TypeFilterLevel.Full;
            propertiesDictionary["name"] = "Channel" + port; // here enter unique channel name
            return new TcpChannel(propertiesDictionary, cp, sp);
        }

        #region EventHandlers


        private void ServerConsoleLog(string text)
        {
            this.Invoke((MethodInvoker) delegate {
                rtbServerOutput.Text += text + "\n";
            });
        }

        private void PlayerOnExitApp()
        {
            this.Close();
        }


        private void PlayerOnFigureChanged(Figure f, string player)
        {
            if (f == Figure.Empty)
            {
                this.btChoose.BackColor = Color.LightGray;
                this.btChoose.ForeColor = Color.Black;
                return;
            }
            this.btChoose.BackColor = Color.SeaGreen;
            this.btChoose.ForeColor = Color.GhostWhite;
        }

        public void PrintResult(Dictionary<IPlayer, Color> resultsDictionary)
        {
            Color color = resultsDictionary[_player];
            var gameResult = "";
            using (var g = CreateGraphics())
            {
                var drawFont = new Font("Arial", 10);
                var drawBrush = new SolidBrush(Color.White);

                if (_game.Winners != null)
                {
                    if (_game.Winners.Count == 0)
                    {
                        gameResult += "Игра закончилась: \n";
                        gameResult += "_____________________ \n";
                        gameResult += "Поздравляем всех, у вас Ничья! \n";
                        foreach (var p in _game.Players)

                            gameResult += "Игрок " + p.Name + " фигура - " + p.Figure + "\n";
                        gameResult += "_____________________ \n";
                        g.Clear(color);

                        g.DrawString(gameResult, drawFont, drawBrush, 11, 50);
                    }
                    else
                    {
                        if (_game.Winners.Count == _game.Players.Count)
                        {
                            gameResult += "Игра закончилась: \n";
                            gameResult += "_____________________ \n \n";
                            gameResult += "Поздравляем всех, у вас Ничья! \n";
                            foreach (var p in _game.Players)
                                gameResult += "Игрок " + p.Name + " фигура - " + p.Figure + "\n";
                            gameResult += "_____________________ \n";
                            g.Clear(color);

                            g.DrawString(gameResult, drawFont, drawBrush, 11, 50);
                        }
                        else
                        {
                            gameResult += "Игра закончилась: \n";
                            gameResult += "_____________________ \n";
                            if (_game.Winners.Count == 1)
                                gameResult += "Победил: \n";
                            else
                                gameResult += "Победили: \n";
                            foreach (var p in _game.Winners)
                                gameResult += "Игрок " + p.Name + " фигура - " + p.Figure + "\n";
                            gameResult += "_____________________ \n";
                            g.Clear(color);

                            g.DrawString(gameResult, drawFont, drawBrush, 11, 50);
                        }
                    }
                }
                else
                {
                    gameResult += "Игра закончилась: \n";
                    gameResult += "_____________________ \n";
                    gameResult += "Поздравляем всех, у вас Ничья! \n";
                    foreach (var p in _game.Players)

                        gameResult += "Игрок " + p.Name + " фигура - " + p.Figure + "\n";
                    gameResult += "_____________________ \n";
                    g.Clear(color);

                    g.DrawString(gameResult, drawFont, drawBrush, 11, 50);
                }
            }
        }

        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            closeClientsToolStripMenuItem.Visible = false;
        }

        private void btEnterName_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new PlayerName();
                form.Text = "Player Name";
                form.ShowDialog();

                _player.Name = form.PName;
                if (!_game.Connect(_player))
                    throw new InvalidOperationException("Can not connect to game Player: " + _player.Name);
                Text = _player.Name;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            if (_player != null)
                if (_player.Figure == Figure.Empty)
                    try
                    {
                        var form = new ChooseFigureForm();
                        form.Text = "Player Figure";
                        form.ShowDialog();

                        _player.Move(form.PlayerChoose);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                else
                    MessageBox.Show("Вы уже походили");
            else
                MessageBox.Show("Сначала введите имя");
        }

        private void ввестиПортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                var form = new PortForm();
                form.Text = "Port";
                form.ShowDialog();
                */
                //_port = _game.GetPortForPlayer();//Convert.ToInt32(form.Port);
                ConnectToServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void запуститьСерверToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void closeClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var player in _game.Players)
            {
                player.Exit();
            }
        }
    }
}