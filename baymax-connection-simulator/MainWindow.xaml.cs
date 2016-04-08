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

        bool leftDoorState = false;
        bool rigthDoorState = false;
        bool hoodState = false;
        bool trunkState = false;

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
            protocol.spoilerModeChanged += Protocol_spoilerModeChanged;
            protocol.suspensionStateChanged += Protocol_suspensionStateChanged;
            protocol.fanSpeedChanged += Protocol_fanSpeedChanged;
            socket.Open();

        }

        private void Protocol_fanSpeedChanged(object sender, ValueSetEventArgs e)
        {
            changeFanSpeedButton(e.Value);
        }

        private void Protocol_suspensionStateChanged(object sender, ValueSetEventArgs e)
        {
            changeSuspensionButton(e.Value);
        }

        private void Protocol_spoilerModeChanged(object sender, ValueSetEventArgs e)
        {
            changeSpoilerButton(e.Value);
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
           /* connectionTimerThread = new Thread(new ThreadStart(Timer));
            timerTime = 0;
            connectionTimerThread.Start();*/
        }

        private void Socket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageBox.Show("Vastaan otettiin uusi viesti " + e.Message);
        }

        private void Socket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void openHoodButtonClicked(object sender, RoutedEventArgs e)
        {
            changeHoodButton();
        }

        private void openLeftDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            changeLeftDoorButton();
        }

        private void openRigthDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            changeRigthDoorButton();
        }

        private void openTrunkButtonClicked(object sender, RoutedEventArgs e)
        {
            changeTrunkButton();
        }

        private void setFanSpeed1ButtonClicked(object sender, RoutedEventArgs e)
        {
            changeFanSpeedButton(1);
            protocol.fanSpeed = 1;
        }

        private void setFanSpeed2ButtonClicked(object sender, RoutedEventArgs e)
        {
            changeFanSpeedButton(2);
            protocol.fanSpeed = 2;
        }

        private void setFanSpeed3ButtonClicked(object sender, RoutedEventArgs e)
        {
            changeFanSpeedButton(3);
            protocol.fanSpeed = 3;
        }

        private void setFanSpeed4ButtonClicked(object sender, RoutedEventArgs e)
        {
            changeFanSpeedButton(4);
            protocol.fanSpeed = 4;
        }

        private void setFanSpeed0ButtonClicked(object sender, RoutedEventArgs e)
        {
            changeFanSpeedButton(0);
            protocol.fanSpeed = 0;
        }

        private void setSuspensionLowClicked(object sender, RoutedEventArgs e)
        {
            changeSuspensionButton(0);
            protocol.suspensionMode = 0;
        }

        private void setSuspensionNormalClicked(object sender, RoutedEventArgs e)
        {
            changeSuspensionButton(1);
            protocol.suspensionMode = 1;
        }

        private void setSuspensionHighClicked(object sender, RoutedEventArgs e)
        {
            changeSuspensionButton(2);
            protocol.suspensionMode = 2;
        }

        private void setSpoilerMode1ButtonClicked(object sender, RoutedEventArgs e)
        {
            changeSpoilerButton(1);
            protocol.spoilerMode = 1;
        }

        private void setSpoilerMode0ButtonClicked(object sender, RoutedEventArgs e)
        {
            changeSpoilerButton(0);
            protocol.spoilerMode = 0;
        }

        private void changeLeftDoorButton()
        {
            if (leftDoorState)
            {
                leftDoorState = false;
                openLeftDoorButton.Background = Brushes.Red;
            }
            else
            {
                leftDoorState = true;
                openLeftDoorButton.Background = Brushes.White;
            }
        }

        private void changeRigthDoorButton()
        {
            if (rigthDoorState)
            {
                rigthDoorState = false;
                openRigthDoorButton.Background = Brushes.Red;
            } else
            {
                rigthDoorState = true;
                openRigthDoorButton.Background = Brushes.White;
            }
        }

        private void changeHoodButton()
        {
            if (hoodState)
            {
                hoodState = false;
                openHoodButton.Background = Brushes.Red;
            } else
            {
                hoodState = true;
                openHoodButton.Background = Brushes.White;
            }
        }

        private void changeTrunkButton()
        {
            if (trunkState)
            {
                trunkState = false;
                openTrunkButton.Background = Brushes.Red;
            } else
            {
                trunkState = true;
                openTrunkButton.Background = Brushes.White;
            }
        }

        private void changeSpoilerButton(uint value)
        {
            switch (value)
            {
                case 0:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setSpoilerMode0Button.Background = Brushes.Blue;
                        setSpoilerMode1Button.Background = Brushes.Beige;
                    }));
                    break;
                case 1:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setSpoilerMode0Button.Background = Brushes.Beige;
                        setSpoilerMode1Button.Background = Brushes.Blue;
                    }));
                    break;
            }
        }

        private void changeSuspensionButton(uint value)
        {
            switch (value)
            {
                case 0:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setSuspensionLowButton.Background = Brushes.Gold;
                        setSuspensionNormalButton.Background = Brushes.HotPink;
                        setSuspensionHighButton.Background = Brushes.HotPink;
                    }));
                    break;
                case 1:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setSuspensionLowButton.Background = Brushes.HotPink;
                        setSuspensionNormalButton.Background = Brushes.Gold;
                        setSuspensionHighButton.Background = Brushes.HotPink;
                    }));
                    break;
                case 2:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setSuspensionLowButton.Background = Brushes.HotPink;
                        setSuspensionNormalButton.Background = Brushes.HotPink;
                        setSuspensionHighButton.Background = Brushes.Gold;
                    }));
                    break;
            }
        }

        private void changeFanSpeedButton(uint value)
        {
            switch (value)
            {
                case 0:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setFanSpeed0Button.Background = Brushes.Green;
                        setFanSpeed1Button.Background = Brushes.Gray;
                        setFanSpeed2Button.Background = Brushes.Gray;
                        setFanSpeed3Button.Background = Brushes.Gray;
                        setFanSpeed4Button.Background = Brushes.Gray;
                    }));
                    break;
                case 1:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setFanSpeed0Button.Background = Brushes.Gray;
                        setFanSpeed1Button.Background = Brushes.Green;
                        setFanSpeed2Button.Background = Brushes.Gray;
                        setFanSpeed3Button.Background = Brushes.Gray;
                        setFanSpeed4Button.Background = Brushes.Gray;
                    }));
                    break;
                case 2:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setFanSpeed0Button.Background = Brushes.Gray;
                        setFanSpeed1Button.Background = Brushes.Gray;
                        setFanSpeed2Button.Background = Brushes.Green;
                        setFanSpeed3Button.Background = Brushes.Gray;
                        setFanSpeed4Button.Background = Brushes.Gray;
                    }));
                    break;
                case 3:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setFanSpeed0Button.Background = Brushes.Gray;
                        setFanSpeed1Button.Background = Brushes.Gray;
                        setFanSpeed2Button.Background = Brushes.Gray;
                        setFanSpeed3Button.Background = Brushes.Green;
                        setFanSpeed4Button.Background = Brushes.Gray;
                    }));
                    break;
                case 4:
                    this.Dispatcher.Invoke((Action) (() =>
                    {
                        setFanSpeed0Button.Background = Brushes.Gray;
                        setFanSpeed1Button.Background = Brushes.Gray;
                        setFanSpeed2Button.Background = Brushes.Gray;
                        setFanSpeed3Button.Background = Brushes.Gray;
                        setFanSpeed4Button.Background = Brushes.Green;
                    }));
                    break;                
            }
        }

        private void setCurrentButtonClicked(object sender, RoutedEventArgs e)
        {
            if (currentValueTextBlock.Text != "")
            {
                uint current;
                bool success = uint.TryParse(currentValueTextBlock.Text, out current);
                if (success)
                {
                    protocol.batteryCurrent = current;
                }
            }
        }

        private void setVoltageButtonClicked(object sender, RoutedEventArgs e)
        {
            if (voltageValueTextBlock.Text != "")
            {
                uint voltage;
                bool success = uint.TryParse(voltageValueTextBlock.Text, out voltage);
                if (success)
                {
                    protocol.batteryVoltage = voltage;
                }
            }
        }
    }
}
