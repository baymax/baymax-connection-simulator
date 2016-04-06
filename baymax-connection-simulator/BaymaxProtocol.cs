using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;
using NanoMessageBus.Serialization;
using Newtonsoft.Json;
using Google.Protobuf;
using System.Windows;

namespace baymax_connection_simulator
{
    class BaymaxProtocol
    {
        private WebSocket webSocket;
        public BaymaxProtocol(WebSocket socket)
        {
            webSocket = socket;
            webSocket.Opened += WebSocket_Opened;
            webSocket.Closed += WebSocket_Closed;
            webSocket.DataReceived += WebSocket_DataReceived;
            webSocket.MessageReceived += WebSocket_MessageReceived;
        }

        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
        
        }

        private void WebSocket_DataReceived(object sender, DataReceivedEventArgs e)
        {
            CommandBuff buff = new CommandBuff();
            buff = CommandBuff.Parser.ParseFrom(e.Data);
            MessageBox.Show("Viesti vastaan otettu");
            MessageBox.Show(buff.SetValueSubCommand.Id.ToString());
        }

        private void WebSocket_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("disconnected");
        }

        private void WebSocket_Opened(object sender, EventArgs e)
        {
            MessageBox.Show("connecte4d");
        }

        public int fanSpeed {
            get;
            set;
        }

        public int suspensionMode {
            get;
            set;
        }

        public int interiorLigth {
            get;
            set;
        }

        public int spoilerMode {
            get;
            set;
        }

        public int engineMode {
            get;
            set;
        }

        public int regenerationMode {
            get;
            set;
        }

        public int batteryVoltage
        {
            get;
            set;
        }

        public int batteryCurrent
        {
            get;
            set;
        }

        public int doorState
        {
            get;
            set;
        }

        public int motionState {
            get;
            set;
        }

        public Dictionary<int, float> temperatures {
            get;
            set;
        }
    }
}
