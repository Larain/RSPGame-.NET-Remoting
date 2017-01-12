using System;
using System.Collections;
using System.Drawing;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Windows.Forms;
using RSPModel;

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

        public void StartServer()
        {
            var sPort = 8900;
            ChannelServices.RegisterChannel(CreateChannel(sPort), false);
            _game = new Game();
            RemotingServices.Marshal(_game, "GameObject");

            Console.WriteLine("Server status is ... OK");
            Console.WriteLine("Port = " + sPort);

            Console.ReadLine();
        }

        private TcpChannel CreateChannel(int port)
        {
            var
                sp = new BinaryServerFormatterSinkProvider();
            sp.TypeFilterLevel = TypeFilterLevel.Full; // Дозволити
            //передачу делегатів
            var
                cp = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();
            props["port"] = port;
            props["typeFilterLevel"] = TypeFilterLevel.Full;
            props["name"] = "Channel" + port; // here enter unique channel name
            return new TcpChannel(props, cp, sp);
        }

        public void ConnectToServer()
        {
            // Створити та зареєструвати канал для взаємодії з сервером
            ChannelServices.RegisterChannel(CreateChannel(_port), false);
            // Отримати посилання на віддалений об'ект-гру
            try
            {
                _game = (Game) Activator.GetObject(typeof(Game), "tcp://localhost:8900/GameObject");
                _game.ShowPlayer += PrintResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PrintResult(Player player)
        {
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
                        g.Clear(Color.Black);

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
                            g.Clear(Color.Black);

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
                            g.Clear(Color.Black);

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
                    g.Clear(Color.Black);

                    g.DrawString(gameResult, drawFont, drawBrush, 11, 50);
                }
            }
        }

        public void RegPlayerOnServer()
        {
            _player = _game.ConnectNewPlayer(_player);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //StartServer();
        }

        private void btEnterName_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new PlayerName();
                form.Text = "Player Name";
                form.ShowDialog();

                _player = new Player(form.PName, Color.Red, _game);
                RegPlayerOnServer();
                Text = _player.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            if (_player != null)
                if (!_player.Moved)
                    try
                    {
                        var form = new ChooseFigureForm();
                        form.Text = "Player Figure";
                        form.ShowDialog();

                        _player.MakeMove(form.PlayerChoose);
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
                var form = new PortForm();
                form.Text = "Port";
                form.ShowDialog();

                _port = Convert.ToInt32(form.Port);
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
    }
}