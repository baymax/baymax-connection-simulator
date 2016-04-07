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
using System.IO;

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

        }

        private void WebSocket_Opened(object sender, EventArgs e)
        {

        }
        int _fanSpeed;
        public int fanSpeed {
            get
            {
                return _fanSpeed;
            }
            set
            {
                _fanSpeed = value;
                ServerCommandBuff buff = new ServerCommandBuff();
                buff.ValueSettedSubCommand = new ValueSettedSubCommand();
                buff.ValueSettedSubCommand.Id = 1;
                buff.ValueSettedSubCommand.IValue = value;
                _suspensionMode = value;
                byte[] data;
                using (var ms = new MemoryStream())
                {
                    buff.WriteTo(ms);
                    data = ms.ToArray();
                }
                webSocket.Send(data, offset: 0, length: data.Length);
            }
        }

        int _suspensionMode;
        public int suspensionMode {
            get
            {
                return _suspensionMode;
            }
            set
            {
                ServerCommandBuff buff = new ServerCommandBuff();
                buff.ValueSettedSubCommand = new ValueSettedSubCommand();
                buff.ValueSettedSubCommand.Id = 4;
                buff.ValueSettedSubCommand.IValue = value;
                _suspensionMode = value;
                byte[] data;
                using (var ms = new MemoryStream())
                {
                    buff.WriteTo(ms);
                    data = ms.ToArray();
                }
                webSocket.Send(data, offset: 0, length: data.Length);
            }
        }

        public int interiorLigth {
            get;
            set;
        }

        int _spoilerMode;
        public int spoilerMode {
            get
            {
                return _spoilerMode;
            }
            set
            {
                _spoilerMode = value;
                ServerCommandBuff buff = new ServerCommandBuff();
                buff.ValueSettedSubCommand = new ValueSettedSubCommand();
                buff.ValueSettedSubCommand.Id = 6;
                buff.ValueSettedSubCommand.IValue = value;
                _suspensionMode = value;
                byte[] data;
                using (var ms = new MemoryStream())
                {
                    buff.WriteTo(ms);
                    data = ms.ToArray();
                }
                webSocket.Send(data, offset: 0, length: data.Length);
            }
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
