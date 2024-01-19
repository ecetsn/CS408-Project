using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace server
{
    public partial class Form1 : Form
    {
        // Declare and initialize the server socket, thread list, and client list
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Thread> threads = new List<Thread>();
        List<ClientInfo> clients = new List<ClientInfo>();

        // Declare flags for terminating and listening
        bool terminating = false;
        bool listening = false;

        // Declare variables to track subscription counts for SPS and IF channels
        int sps_sub_count = 0;
        int if_sub_count = 0;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
            richTextBox_clients.Enabled = false;
            richTextBox_if.Enabled = false;
            richTextBox_sps.Enabled = false;
        }

        // Handles the button click event for starting the server and listening for incoming connections
        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;
            // Attempt to parse the port number from the textBox_port
            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                // Create an endpoint with the specified IP address and port number
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);

                // Bind the server socket to the endpoint and start listening with a backlog of 3
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                // Set the listening flag to true and disable the listen button
                listening = true;
                button_listen.Enabled = false;

                // Start a new thread for handling incoming connections
                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                // Log that the server has started listening on the specified port
                logs.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                // Log a message if parsing the port number fails
                logs.AppendText("Please check port number \n");
            }
        }

        // Parses a string into command, username, and message components
        private void parse_line(string line, ref string command, ref string username, ref string message)
        {
            // Find the indices of "[" and "]"
            int a = line.IndexOf("[") + 1;
            int b = line.IndexOf("]");

            // Extract the command between "[" and "]"
            command = line.Substring(a, b - a);

            // Find the indices of "(" and ")"
            int c = line.IndexOf("(") + 1;
            int d = line.IndexOf(")");

            // Extract the username between "(" and ")"
            username = line.Substring(c, d - c);

            // Find the index of ")" and check if there is a message present
            int e = line.IndexOf(")") + 1;

            if (e < line.Length)
            {
                message = line.Substring(e).Trim(); // Extract the message after ")"
            }
            else
            {
                message = string.Empty; // No message found
            }
        }

        // Listens for incoming connection requests and handles new client acceptance
        private void Accept()
        {
            while (listening)
            {
                try
                {
                    // Accept a new client connection
                    Socket newClient = serverSocket.Accept();

                    // Initialize variables to store command, username, and message
                    string command = "";
                    string username = "";
                    string message = "";

                    // Receive initial data from the new client
                    Byte[] buffer = new Byte[64];
                    newClient.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    // Parse the incoming message into command, username, and message
                    parse_line(incomingMessage, ref command, ref username, ref message);
                    // Check if the username is unique
                    bool isUsernameUnique = CheckUsername(newClient, username);

                    if (isUsernameUnique)
                    {
                        // Get information about the accepted client
                        ClientInfo acceptedClient = clients.Find(c => c.Socket == newClient);

                        // Create a new thread for receiving messages from the accepted client
                        Thread receiveThread = new Thread(() => Receive(newClient));
                        threads.Add(receiveThread);

                        // Start the receive thread
                        receiveThread.Start();

                        // Update the connected count
                        connected_count.Text = (clients.Count()).ToString();
                    }
                    else
                    {
                        // Log if a user attempts to connect with a non-unique username
                        logs.AppendText($"A user trying to connect with a non-unique username ({username}).\n");
                    }
                }
                catch (Exception ex)
                {
                    // Check if the server is terminating, stop listening if true
                    if (terminating)
                    {
                        listening = false;
                    }
                }
            }
        }

        // Checks if a username is unique among connected clients and takes appropriate actions
        private bool CheckUsername(Socket clientSocket, string username)
        {
            // Check if the username is unique
            bool unique = !clients.Any(c => c.Username == username);

            if (unique)
            {
                // If the username is unique, create a new ClientInfo instance and add it to the clients list
                ClientInfo newClientInfo = new ClientInfo(clientSocket, username);
                clients.Add(newClientInfo);

                // Send a positive response to the client
                clientSocket.Send(Encoding.Default.GetBytes("pos"));

                // Broadcast the user joining message to all clients
                BroadcastToClients($"The user \"{username}\" has joined the server", "CONNECT", newClientInfo);
                logs.AppendText($"The user \"{username}\" has joined the server\n");

                // Update status on client log
                richTextBox_clients.Clear();
                foreach (ClientInfo client in clients)
                {
                    richTextBox_clients.AppendText(client.Username + "\n");
                }
                // Return true to indicate a unique username
                return true;
            }
            else
            {
                // If the username is not unique, send a negative response to the client and disconnect
                ClientInfo disconnectedClient = clients.Find(c => c.Socket == clientSocket);
                clientSocket.Send(Encoding.Default.GetBytes("neg"));
                // Removing the connection made before to check if username is unique
                Disconnect(clientSocket, username);
                // Return false to indicate a non-unique username
                return false;
            }
        }

        // Broadcasts a message to all connected clients based on the specified command and sender information
        private void BroadcastToClients(string message, string command, ClientInfo sender)
        {
            try
            {
                // Broadcast a general log message for CONNECT and DISCONNECT commands
                if (command == "CONNECT" || command == "DISCONNECT")
                {
                    foreach (ClientInfo client in clients)
                    {
                        client.Socket.Send(Encoding.Default.GetBytes($"[LOG](SERVER){message}"));
                    }
                }
                // Broadcast subscription message for clients subscribed to IF channel
                if (command == "IFSUB")
                {
                    foreach (ClientInfo client in clients)
                    {
                        if (client.SubscribedChannels.Contains("IF"))
                        {
                            client.Socket.Send(Encoding.Default.GetBytes($"[IFMES](SERVER)The user \"{sender.Username}\" has subscribed to IF channel"));
                        }
                    }
                }
                // Broadcast a message for clients subscribed to IF channel
                if (command == "IFMES")
                {
                    foreach (ClientInfo client in clients)
                    {
                        if (client.SubscribedChannels.Contains("IF"))
                        {
                            client.Socket.Send(Encoding.Default.GetBytes($"[IFMES]({sender.Username}){message}"));
                        }
                    }
                }
                // Broadcast unsubscription message for clients subscribed to IF channel
                if (command == "IFUNS")
                {
                    foreach (ClientInfo client in clients)
                    {
                        if (client.SubscribedChannels.Contains("IF"))
                        {
                            client.Socket.Send(Encoding.Default.GetBytes($"[IFMES](SERVER)The user \"{sender.Username}\" has unsubscribed from IF channel"));
                        }
                    }
                }
                // Broadcast subscription message for clients subscribed to SPS channel
                if (command == "SPSUB")
                {
                    foreach (ClientInfo client in clients)
                    {
                        if (client.SubscribedChannels.Contains("SPS"))
                        {
                            client.Socket.Send(Encoding.Default.GetBytes($"[SPSMES](SERVER)The user \"{sender.Username}\" has subscribed to SPS channel"));
                        }
                    }
                }
                // Broadcast a message for clients subscribed to SPS channel
                if (command == "SPSMES")
                {
                    foreach (ClientInfo client in clients)
                    {
                        if (client.SubscribedChannels.Contains("SPS"))
                        {
                            client.Socket.Send(Encoding.Default.GetBytes($"[SPSMES]({sender.Username}){message}"));
                        }
                    }
                }
                // Broadcast unsubscription message for clients subscribed to SPS channel
                if (command == "SPSUN")
                {
                    foreach (ClientInfo client in clients)
                    {
                        if (client.SubscribedChannels.Contains("SPS"))
                        {
                            client.Socket.Send(Encoding.Default.GetBytes($"[SPSMES](SERVER)The user \"{sender.Username}\" has unsubscribed to SPS channel"));
                        }
                    }
                }
                // Broadcast disconnection message for clients subscribed to SPS channel
                if (command == "DISSPS")
                {
                    foreach (ClientInfo client in clients)
                    {
                        if (client.SubscribedChannels.Contains("SPS"))
                        {
                            client.Socket.Send(Encoding.Default.GetBytes($"[DISSPS](SERVER)The user \"{sender.Username}\" has left the server"));
                        }
                    }
                }
                // Broadcast disconnection message for clients subscribed to IF channel
                if (command == "DISIF")
                {
                    foreach (ClientInfo client in clients)
                    {
                        if (client.SubscribedChannels.Contains("IF"))
                        {
                            client.Socket.Send(Encoding.Default.GetBytes($"[DISIF](SERVER)The user \"{sender.Username}\" has left the server"));
                        }
                    }
                }

            }
            catch (SocketException ex)
            {
                // Handle any exceptions that may occur during message broadcasting
            }
        }


        // Listens for incoming messages from a client and processes them accordingly
        private void Receive(Socket thisClient)
        {
            // Initialize variables to store command, username, and message
            string command = "";
            string username = "";
            string message = "";
            try
            {
                // Continue receiving messages while the client is connected
                while (thisClient.Connected)
                {
                    // Initialize a buffer to store received data
                    Byte[] buffer = new Byte[64];
                    // Receive data from the client
                    thisClient.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    // Parse the incoming message into command, username, and message
                    parse_line(incomingMessage, ref command, ref username, ref message);

                    // Check if the command is DISCONNECT to avaoid sleeping thread problem
                    if (command == "DISCONNECT")
                    {
                        break;
                    }
                    ProcessCommand(thisClient, command, username, message);
                }
                // Process the DISCONNECT command after the loop to handle client disconnection
                ProcessCommand(thisClient, command, username, message);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during message reception
            }
        }


        // Handles various commands received from clients and performs corresponding actions
        private void ProcessCommand(Socket clientSocket, string command, string username, string message)
        {
            if (command == "CONNECT")
            {
                bool isUsernameUnique = CheckUsername(clientSocket, username);

                if (isUsernameUnique)
                {
                    // Create a new thread for receiving messages from the client
                    Thread receiveThread = new Thread(() => Receive(clientSocket));
                    threads.Add(receiveThread);
                    receiveThread.Start();
                    // Get the connected client information to appent the username
                    ClientInfo connectedClient = clients.Find(c => c.Socket == clientSocket);
                    logs.AppendText($"The user \"{username}\" has joined the server\n");
                    // update status is done by CheckUsername
                }
                else
                {
                    // If the username is not unique, reject the connection
                    ClientInfo rejectedClient = clients.Find(c => c.Socket == clientSocket);
                    Disconnect(clientSocket, username);
                    logs.AppendText($"A user trying to connect with a non-unique username ({username}).\n");
                }

            }
            // Process DISCONNECT command
            if (command == "DISCONNECT")
            {
                ClientInfo disconnectedClient = clients.Find(c => c.Socket == clientSocket);
                // Broadcast a general disconnect message to channels and update server logs
                if (disconnectedClient.SubscribedChannels.Contains("SPS") && disconnectedClient.SubscribedChannels.Contains("IF"))
                {
                    disconnectedClient.Socket.Send(Encoding.Default.GetBytes($"[DISALL](SERVER)The user \"{disconnectedClient.Username}\" has left the server"));
                    BroadcastToClients(message, "DISSPS", disconnectedClient);
                    BroadcastToClients(message, "DISIF", disconnectedClient);
                    sps_sub_count = (sps_sub_count > 0) ? sps_sub_count - 1 : 0;
                    sps_count.Text = (sps_sub_count).ToString();
                    if_sub_count = (if_sub_count > 0) ? if_sub_count - 1 : 0;
                    if_count.Text = (if_sub_count).ToString();
                    disconnectedClient.SubscribedChannels.Remove("SPS");
                    disconnectedClient.SubscribedChannels.Remove("IF");
                }
                if (disconnectedClient.SubscribedChannels.Contains("IF")) 
                {
                    BroadcastToClients(message, "DISIF", disconnectedClient);
                    if_sub_count = (if_sub_count > 0) ? if_sub_count - 1 : 0;
                    if_count.Text = (if_sub_count).ToString();
                    disconnectedClient.SubscribedChannels.Remove("IF");
                }
                if (disconnectedClient.SubscribedChannels.Contains("SPS") )
                {
                    BroadcastToClients(message, "DISSPS", disconnectedClient);
                    sps_sub_count = (sps_sub_count > 0) ? sps_sub_count - 1 : 0;
                    sps_count.Text = (sps_sub_count).ToString();
                    disconnectedClient.SubscribedChannels.Remove("SPS");
                }
                // Broadcast a general disconnect message to all clients
                BroadcastToClients($"The user \"{username}\" has left the server", "DISCONNECT", disconnectedClient);                
                Disconnect(clientSocket, username);
                // update the status on server log
                logs.AppendText($"The user \"{username}\" has left the server\n");
                // update status on client log
                richTextBox_clients.Clear();
                foreach (ClientInfo client in clients)
                {
                    richTextBox_clients.AppendText(client.Username + "\n");
                }
                // update status on if log
                richTextBox_if.Clear();
                foreach (ClientInfo client in clients)
                {
                    if (client.SubscribedChannels.Contains("IF")) 
                    {
                        richTextBox_if.AppendText(client.Username + "\n");
                    }
                }
                // update status on sps log
                richTextBox_sps.Clear();
                foreach (ClientInfo client in clients)
                {
                    if (client.SubscribedChannels.Contains("SPS")) 
                    {
                        richTextBox_sps.AppendText(client.Username + "\n");
                    }
                }
                connected_count.Text = clients.Count().ToString();
            }
            // Process IFMES command and broadcast to relevant clients
            if (command == "IFMES")
            {
                ClientInfo connectedClient = clients.Find(c => c.Socket == clientSocket);
                BroadcastToClients(message, "IFMES", connectedClient);
                logs.AppendText($"The user \"{username}\" is sending the message \"{message}\" to IF Channel.\n");
            }
            // Process SPSMES command and broadcast to relevant clients
            if (command == "SPSMES")
            {
                ClientInfo connectedClient = clients.Find(c => c.Socket == clientSocket);
                BroadcastToClients(message, "SPSMES", connectedClient);
                logs.AppendText($"The user \"{username}\" is sending the message \"{message}\"  to SPS Channel.\n");
            }
            // Process IFSUB command and broadcast to relevant clients
            if (command == "IFSUB")
            {
                ClientInfo connectedClient = clients.Find(c => c.Socket == clientSocket);
                connectedClient.SubscribedChannels.Add("IF");
                BroadcastToClients(message, "IFSUB", connectedClient);
                logs.AppendText($"The user \"{username}\" has subscribed to IF Channel.\n");
                // update status on if log
                richTextBox_if.Clear();
                foreach (ClientInfo client in clients)
                {
                    if (client.SubscribedChannels.Contains("IF"))
                    {
                        richTextBox_if.AppendText(client.Username + "\n");
                    }                     
                }
                if_count.Text = (++if_sub_count).ToString();
            }
            // Process SPSUB command and broadcast to relevant clients
            if (command == "SPSUB")
            {
                ClientInfo connectedClient = clients.Find(c => c.Socket == clientSocket);
                connectedClient.SubscribedChannels.Add("SPS");
                BroadcastToClients(message, "SPSUB", connectedClient);
                logs.AppendText($"The user \"{username}\" has subscribed to SPS Channel.\n");
                // update status on sps log
                richTextBox_sps.Clear();
                foreach (ClientInfo client in clients)
                {
                    if (client.SubscribedChannels.Contains("SPS"))
                    {
                        richTextBox_sps.AppendText(client.Username + "\n");
                    }
                }
                sps_count.Text = (++sps_sub_count).ToString();
            }
            // Process IFSUNS command and broadcast to relevant clients
            if (command == "IFUNS")
            {
                ClientInfo connectedClient = clients.Find(c => c.Socket == clientSocket);
                BroadcastToClients(message, "IFUNS", connectedClient);
                connectedClient.SubscribedChannels.Remove("IF");
                logs.AppendText($"The user \"{username}\" has unsubscribed from IF Channel\n");
                // update status on if log
                richTextBox_if.Clear();
                foreach (ClientInfo client in clients)
                {
                    if (client.SubscribedChannels.Contains("IF"))
                    {
                        richTextBox_if.AppendText(client.Username + "\n");
                    }
                }
                if_count.Text = (--if_sub_count).ToString();
            }
            // Process SPSUN command and broadcast to relevant clients
            if (command == "SPSUN")
            {
                ClientInfo connectedClient = clients.Find(c => c.Socket == clientSocket);
                BroadcastToClients(message, "SPSUN", connectedClient);
                connectedClient.SubscribedChannels.Remove("SPS");
                logs.AppendText($"The user \"{username}\" has unsubscribed from SPS Channel\n");
                // update status on sps log
                richTextBox_sps.Clear();
                foreach (ClientInfo client in clients)
                {
                    if (client.SubscribedChannels.Contains("SPS"))
                    {
                        richTextBox_sps.AppendText(client.Username + "\n");
                    }
                }
                sps_count.Text = (--sps_sub_count).ToString();
            }
        }

        // Handles disconnecting a client from the server
        private void Disconnect(Socket clientSocket, String username)
        {

            ClientInfo disconnectedClient = clients.Find(c => c.Socket == clientSocket);
            if (clientSocket != null)
            {
                clients.Remove(disconnectedClient);
            }
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        // Necessary settings for direct form closings
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Set the listening flag to false to stop accepting new clients
            listening = false;

            // Set the terminating flag to true to signal that the server is shutting down
            terminating = true;

            // Create a copy of the clients list to avoid modification during iteration
            List<ClientInfo> clientsCopy = new List<ClientInfo>(clients);
            foreach (ClientInfo clientInfo in clientsCopy)
            {
                Disconnect(clientInfo.Socket, clientInfo.Username);
            }
            // wait for the thread of disconnected client to end
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox_port_TextChanged(object sender, EventArgs e)
        {

        }
    }
    // Keep all the client information as an object
    public class ClientInfo
    {
        public Socket Socket { get; set; }
        public string Username { get; set; }
        public List<string> SubscribedChannels { get; set; }
        public ClientInfo(Socket socket, string username)
        {
            Socket = socket;
            Username = username;
            SubscribedChannels = new List<string>();
        }
    }
}
