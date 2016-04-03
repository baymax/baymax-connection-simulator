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

namespace baymax_connection_simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebSocket socket;
        public MainWindow()
        {
            InitializeComponent();

            socket = new WebSocket("ws://10.70.0.46/", "", null, null, "", "//baymax", WebSocketVersion.None, null);
            socket.Opened += Socket_Opened;
            socket.Open();
        }

        private void Socket_Opened(object sender, EventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)4, (char)0 }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)4, (char)1 }));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)4, (char)2 }));
        }

        private void setFanSpeed0Button(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)1, (char)0 }));
        }

        private void setFanSpeed1Button(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)1, (char)1 }));
        }

        private void setFanSpeed2Button(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)1, (char)2 }));
        }

        private void setFanSpeed3Button(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)1, (char)3 }));
        }

        private void setFanSpeed4Button(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)1, (char)4 }));
        }

        private void setSpoilerMode1Button(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)6, (char)1 }));
        }

        private void setSpoilerMode0Button(object sender, RoutedEventArgs e)
        {
            socket.Send(new string(new char[] { (char)1, (char)6, (char)0 }));
        }
    }
}
