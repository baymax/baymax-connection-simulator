using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebSocket4Net;
using NanoMessageBus.Serialization;
using System.Threading;

namespace baymax_connection_simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebSocket socket;
        BaymaxProtocol protocol;

        KeyValuePair<string, string> authPair;

        Thread connectionTimerThread;

        int timerTime = 0;
        int exTime = 170;
        bool closeTimer = false;

        public MainWindow()
        {
            InitializeComponent();
            string userName = "baymax";
            string userPassword = "baymax";
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            authPair = new KeyValuePair<string, string>("Authorization", "Basic " + authInfo);
            socket = new WebSocket("ws://baymax.severi.dy.fi:8080/", "", null, new List<KeyValuePair<string, string>> { authPair }, "", "//baymax", WebSocketVersion.None, null);
            protocol = new BaymaxProtocol(socket);
            socket.Opened += Socket_Opened1;
            socket.Closed += Socket_Closed;
            socket.Open();

        }

        private void Socket_Opened1(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke((Action) (() =>
            {
                connectionStateIndicator.Background = Brushes.Green;
                connectionStateIndicator.Text = "connected";
            }));
            closeTimer = true;
        }

        private void Socket_Closed(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke((Action) (() =>
            {
                connectionStateIndicator.Background = Brushes.Red;
                connectionStateIndicator.Text = "disconnected";
            }));
            closeTimer = false;
            connectionTimerThread = new Thread(new ThreadStart(Timer));
            timerTime = 0;
            connectionTimerThread.Start();            
        }

        private void Timer()
        {
            for (; timerTime < exTime; timerTime++)
            {
                Console.WriteLine(timerTime);
                Thread.Sleep(10);
                if (closeTimer) return;
            }
            socket.Open();
            connectionTimerThread = new Thread(new ThreadStart(Timer));
            timerTime = 0;
            connectionTimerThread.Start();
        }

        private void Socket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageBox.Show("Vastaan otettiin uusi viesti " + e.Message);
        }

        private void Socket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            protocol.suspensionMode = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            protocol.suspensionMode = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            protocol.suspensionMode = 2;
        }

        private void setFanSpeed0Button(object sender, RoutedEventArgs e)
        {
            protocol.fanSpeed = 0;
        }

        private void setFanSpeed1Button(object sender, RoutedEventArgs e)
        {
            protocol.fanSpeed = 1;
        }

        private void setFanSpeed2Button(object sender, RoutedEventArgs e)
        {
            protocol.fanSpeed = 2;
        }

        private void setFanSpeed3Button(object sender, RoutedEventArgs e)
        {
            protocol.fanSpeed = 3;
        }

        private void setFanSpeed4Button(object sender, RoutedEventArgs e)
        {

            protocol.fanSpeed = 4;
        }

        private void setSpoilerMode1Button(object sender, RoutedEventArgs e)
        {
            protocol.spoilerMode = 1;
        }

        private void setSpoilerMode0Button(object sender, RoutedEventArgs e)
        {
            protocol.spoilerMode = 0;
        }
    }
}
