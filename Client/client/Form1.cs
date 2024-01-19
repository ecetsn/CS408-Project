using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        bool if_sub = false;
        bool sps_sub = false;

        bool terminating = false;
        bool connected = false;
        Socket clientSocket;
        string username = "";

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        // will be used to change UI elements when
        // the user gets connected to the server
        private void connectedChanges() 
        {
            textBox_ip.Enabled = false;
            textBox_port.Enabled = false;
            textBox_name.Enabled = false;
            button_connect.Enabled = false;
            button_if_unsub.Enabled = false;
            button_sps_unsub.Enabled = false;

            button_disconnect.Enabled = true;
            textBox_message.Enabled = true;
            button_send.Enabled = true;
            groupBox1.Enabled = true;
            button_sps_sub.Enabled = true;
            button_if_sub.Enabled = true;
            button_clear_connection.Enabled = true;
            button_clear_if.Enabled = true;
            button_clear_sps.Enabled = true;

            textBox_message.Text = string.Empty;
        }

        private void disconnectedChanges() 
        {
            // Disable relevant UI elements
            button_disconnect.Enabled = false;
            textBox_message.Enabled = false;
            button_send.Enabled = false;
            groupBox1.Enabled = false;
            connected = false;
            button_if_unsub.Enabled = false;
            button_sps_unsub.Enabled = false;
            button_sps_sub.Enabled = false;
            button_if_sub.Enabled = false;
            groupBox1.Enabled = false;
            textBox_message.Enabled = false;
            radioButton_if.Checked = false;
            radioButton_sps.Checked = false;

            // Enable relevant UI elements
            button_connect.Enabled = true;
            textBox_ip.Enabled = true;
            textBox_port.Enabled = true;
            textBox_name.Enabled = true;

            // Reset chosen channel to default
            label11.Text = "...";
            textBox_message.Text = string.Empty;
        }




        // Handles the process of connecting to the server
        private void button_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_ip.Text;

            int portNum;
            if (Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    username = textBox_name.Text;

                    clientSocket.Connect(IP, portNum);

                    connected = true;

                    string message_to_send = "[CONNECT](" + username + ")";
                    clientSocket.Send(Encoding.Default.GetBytes(message_to_send));

                    // will be used to check if the server has accepted the connection
                    Byte[] responseBuffer = new Byte[4];
                    clientSocket.Receive(responseBuffer); 
                    string response = Encoding.Default.GetString(responseBuffer).Substring(0, 3);

                    if (response == "pos") // If server accepts the username
                    {
                        // Change UI elements accordingly
                        connectedChanges();
                        
                        // Create thread to listen to the server
                        Thread receiveThread = new Thread(Receive);
                        receiveThread.Start();

                    }
                    else if (response == "neg") // If the server rejects the connection due to non-unique username
                    {
                        connection_log.AppendText("Username is taken try another one\n");
                    }
                }
                catch
                {
                    connection_log.AppendText("Could not connect to the server!\n");
                }
            }
            else
            {
                connection_log.AppendText("Check the port\n");
            }
        }

        // will be used as a helper funcction
        // command is used to understand what type of message it is 
        // username is used the name of the sender
        // message stands for the message that is being received
        private void parse_message(string line, ref string command, ref string username, ref string message)
        {
            int a = line.IndexOf('[') + 1;
            int b = line.IndexOf(']');
            int c = line.IndexOf('(') + 1;
            int d = line.IndexOf(')');

            command = line.Substring(a, b - a);
            username = line.Substring(c, d - c);
            message = line.Substring(d + 1);
        }

        // Will be used to listen to the server
        private void Receive()
        {
            string command = "";
            string sender = "";
            string message = "";
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    string serverMessage = Encoding.Default.GetString(buffer);
                    serverMessage = serverMessage.Substring(0, serverMessage.IndexOf("\0"));

                    parse_message(serverMessage, ref command, ref sender, ref message);
                    // It is an information related with server activities
                    // regardless of the channel (user connect, disconnect etc.)
                    if (command == "LOG")
                    {
                        string post = "[" + sender + "]: " + message + "\n";
                        connection_log.AppendText(post);
                    }
                    // If it is related with IF100
                    if (command == "IFMES")
                    {
                        string post = "[" + sender + "]: " + message + "\n";
                        if100_log.AppendText(post);
                    }
                    // If it is related with SPS101
                    if (command == "SPSMES")
                    {
                        string post = "[" + sender + "]: " + message + "\n";
                        sps101_log.AppendText(post);
                    }
                    // If the user is leaving both channels and the server
                    if (command == "DISALL")
                    {
                        string post = "[" + sender + "]: " + message + "\n";
                        sps101_log.AppendText(post);
                        if100_log.AppendText(post);
                        connection_log.AppendText(post);
                    }
                    // If the user is leaving SPS101 channel
                    if (command == "DISSPS")
                    {
                        string post = "[" + sender + "]: " + message + "\n";
                        sps101_log.AppendText(post);
                    }
                    // If the user is leaving IF100 channel
                    if (command == "DISIF")
                    {
                        string post = "[" + sender + "]: " + message + "\n";
                        if100_log.AppendText(post);
                    }
                }
                catch
                {
                    // client is not terminating and still connected
                    // however it cannot receive messages meaning that
                    // the server has disconnected
                    if (!terminating && connected)
                    {
                        connection_log.AppendText("The server has disconnected\n");
                        // Change UI elements accordingly
                        disconnectedChanges();
                    }
                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            button_disconnect_Click_1(sender, e);
            // close the connection automatically just in 
            // case the user did not disconnect before leaving
            Environment.Exit(0);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            // check if the user is subscribed to that channel
            if (radioButton_if.Checked == true && if_sub == false)
            {
                connection_log.AppendText("To send message to the IF channel you must subscribe to that channel\n");
            }
            // check if the user is subscribed to that channel
            else if (radioButton_sps.Checked == true && sps_sub == false)
            {
                connection_log.AppendText("To send message to the SPS channel you must subscribe to that channel\n");
            }
            // check if the user is subscribed to that channel
            else if (label11.Text == "...")
            {
                connection_log.AppendText("Subscribe to a channel\n");
            }

            // check if the user is sending empty message (might cause spamming)
            else if (textBox_message.Text == "") 
            {
                connection_log.AppendText("You cannot send an empty message\n");
            }
            else
            {
                // prefix is used so that the server can parse the message
                string prefix = "";
                string user_message = textBox_message.Text;
                if (radioButton_if.Checked) { prefix = "[IFMES]"; }
                else if (radioButton_sps.Checked) { prefix = "[SPSMES]"; }
                string message_to_send = prefix + "(" + username + ")" + user_message;
                clientSocket.Send(Encoding.Default.GetBytes(message_to_send));
                textBox_message.Text = string.Empty;
            }
        }

        // following functions will change the appearance of the GUI
        // and send commands to the server
        private void button_if_sub_Click(object sender, EventArgs e)
        {
            if_sub = true;
            button_if_sub.Enabled = false;
            button_if_unsub.Enabled = true;
            string message = "[IFSUB](" + username + ")";
            clientSocket.Send(Encoding.Default.GetBytes(message));
        }

        private void button_if_unsub_Click(object sender, EventArgs e)
        {
            if_sub = false;
            button_if_sub.Enabled = true;
            button_if_unsub.Enabled = false;
            string message = "[IFUNS](" + username + ")";
            clientSocket.Send(Encoding.Default.GetBytes(message));
        }

        private void button_sps_sub_Click(object sender, EventArgs e)
        {
            sps_sub = true;
            button_sps_sub.Enabled = false;
            button_sps_unsub.Enabled = true;
            string message = "[SPSUB](" + username + ")";
            clientSocket.Send(Encoding.Default.GetBytes(message));
        }

        private void button_sps_unsub_Click(object sender, EventArgs e)
        {
            sps_sub = false;
            button_sps_sub.Enabled = true;
            button_sps_unsub.Enabled = false;
            string message = "[SPSUN](" + username + ")";
            clientSocket.Send(Encoding.Default.GetBytes(message));
        }

        // to show the chosen channel to the user
        private void radioButton_if_CheckedChanged(object sender, EventArgs e)
        {
            label11.Text = "IF100";
        }

        private void radioButton_sps_CheckedChanged(object sender, EventArgs e)
        {
            label11.Text = "SPS101";
        }

        private void button_disconnect_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Inform the server that the client is disconnecting
                string disconnectMessage = "[DISCONNECT](" + username + ")";
                clientSocket.Send(Encoding.Default.GetBytes(disconnectMessage));
                connected = false;
                
                // Change UI elements accordingly
                disconnectedChanges();
            }
            catch (Exception ex)
            {
                connection_log.AppendText($"An error occurred while disconnecting: {ex.Message}\n");
            }
        }
        // following functions are used to clear the log records for channels
        private void button_clear_connection_Click(object sender, EventArgs e)
        {
            connection_log.Text = string.Empty; 
        }

        private void button_clear_if_Click(object sender, EventArgs e)
        {
            if100_log.Text = string.Empty;
        }

        private void button_clear_sps_Click(object sender, EventArgs e)
        {
            sps101_log.Text = string.Empty;
        }
    }
}