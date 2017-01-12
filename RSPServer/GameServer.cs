using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using RSPModel;

namespace GameRSPServer
{
    internal class GameServer
    {
        private static Game _game;

        private static void Main(string[] args)
        {
            var port = 8900;
            ChannelServices.RegisterChannel(CreateChannel(port), false);
            _game = new Game();
            RemotingServices.Marshal(_game, "GameObject");

            Console.WriteLine("Server status is ... OK");
            Console.WriteLine("Port = " + port);

            Console.ReadLine();
        }

        private static TcpChannel CreateChannel(int port)
        {
            var
                sp = new BinaryServerFormatterSinkProvider();
            sp.TypeFilterLevel = TypeFilterLevel.Full;
            var
                cp = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();
            props["port"] = port;
            props["typeFilterLevel"] = TypeFilterLevel.Full;
            props["name"] = "Channel" + port;
            return new TcpChannel(props, cp, sp);
        }
    }
}