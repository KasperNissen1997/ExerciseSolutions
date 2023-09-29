using System.Net.Sockets;
using System.Net;
using System.Text;

namespace OnlineAuktionshus.AuktionsServer
{
    public class AuktionsServer
    {
        private const int port = 30000;
        private Socket ListenerSocket;
        public Tools.State State { get; set; } = Tools.State.RUNNING;
        public List<Socket> ClientSockets { get; set; } = new();

        private static void Main(string[] args)
        {
            AuktionsServer program = new();
            program.Run();
        }

        private void Run()
        {
            Console.WriteLine("Starting server...");

            IPAddress address = Tools.GetIPAddress();

            try
            {
                ListenerSocket = new(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint localEndPoint = new(address, port);
                ListenerSocket.Bind(localEndPoint);
                ListenerSocket.Listen();

                Console.WriteLine($"Listening for connection on {ListenerSocket.LocalEndPoint}... ");

                do
                {
                    Socket clientSocket = ListenerSocket.Accept();
                    ClientSockets.Add(clientSocket);
                    Console.WriteLine($"Caught one at {clientSocket.LocalEndPoint}...");

                    Thread clientHandlerThread = new(new ParameterizedThreadStart(HandleClient));
                    clientHandlerThread.Start(clientSocket);
                }
                while (State == Tools.State.RUNNING);
            }
            catch (SocketException ex)
            {
                // Console.WriteLine(ex.Message);
            }
        }

        private void HandleClient(object client)
        {
            if (client is not Socket)
                throw new Exception("Unexpected error converting object to Socket.");

            Socket clientSocket = (Socket) client;

            byte[] bytes = new byte[1024];
            int highestBid = 0;
            string data;

            bool isConnected = true;

            do
            {
                try
                {
                    int numByte = clientSocket.Receive(bytes);

                    data = Encoding.ASCII.GetString(bytes, 0, numByte);
                    data = data.ToUpper();

                    if (!ValidDataSyntax(data))
                    {
                        clientSocket.Send(Encoding.ASCII.GetBytes("Wrong syntax!"));
                        continue;
                    }

                    char messageType = data[0];
                    string argument = data[2..]; // Equal to .SubString(2), we're Python now!
                    argument = argument.Remove(argument.Length - 1);

                    switch (messageType)
                    {
                        case 'B':
                            highestBid = Bid(clientSocket, argument, highestBid);
                            break;

                        case 'C':
                            switch (argument)
                            {
                                case "EXIT":
                                    DisconnectClient(clientSocket, true, "Bye!");
                                    isConnected = false;
                                    break;

                                case "CLOSESERVER":
                                    CloseServer();
                                    isConnected = false;
                                    break;
                            }
                            break;
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Problems reading client - disconnecting");
                    DisconnectClient(clientSocket);
                    isConnected = false;
                    // Close connection to the client.
                }
            }
            while (isConnected);
        }

        /// <summary>
        /// Closes the 
        /// </summary>
        private void CloseServer()
        {
            Console.WriteLine("Attempting to close server...");

            try
            {
                foreach (Socket clientSocket in new List<Socket>(ClientSockets))
                    DisconnectClient(clientSocket, false, "Disconnected from server as server is closing.");

                ListenerSocket.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Error message:\n" + ex.Message);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSUCCES\n");
            Console.ForegroundColor = ConsoleColor.White;

            State = Tools.State.CLOSESERVER;
        }

        /// <summary>
        /// Closes the connection to the socket, <paramref name="clientSocket"/>. If there is no connection, nothing happens.
        /// </summary>
        /// <param name="clientSocket">The socket that should be disconnected from.</param>
        private void DisconnectClient(Socket clientSocket, bool logToConsole = false, string messageToClient = null)
        {
            if (!clientSocket.Connected)
                return;

            if (messageToClient != null)
                clientSocket.Send(Encoding.ASCII.GetBytes(messageToClient));

            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();

            ClientSockets.Remove(clientSocket);

            if (logToConsole)
                Console.WriteLine("Finished handling a client...");
        }

        private static int Bid(Socket client, string argument, int highestBid)
        {
            int result = highestBid;

            if (int.TryParse(argument, out var bid))
                if (bid > highestBid)
                {
                    result = bid;
                    client.Send(Encoding.ASCII.GetBytes("OK"));
                }
                else
                    client.Send(Encoding.ASCII.GetBytes("Bid is too low"));
            else
                client.Send(Encoding.ASCII.GetBytes("Bid is not integer"));

            return result;
        }

        private bool ValidDataSyntax(string data)
        {
            //Valid data: X@Y#
            //X (a char) is type of message , Y is message itself, @ and # are delimiters
            //B : bid (then the message holds the amount)
            //C : Command (message then tells to exit client or to close server - more to come...)
            //more to come... 
            return (data.Length >= 4)
                && ((data[0] == 'B') || (data[0] == 'C'))
                && (data[1] == '@')
                && (data[data.Length - 1] == '#');

        }
    }
}
