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
        public event EventHandler<ValueSetEventArgs> suspensionStateChanged;
        public event EventHandler<ValueSetEventArgs> fanSpeedChanged;
        public event EventHandler<ValueSetEventArgs> spoilerModeChanged;
        public event EventHandler<ValueSetEventArgs> leftDoorState;
        public event EventHandler<ValueSetEventArgs> rigthDoorState;
        public event EventHandler<ValueSetEventArgs> hoodState;
        public event EventHandler<ValueSetEventArgs> trunkState;

        private void raiseLeftDoorStateChanged(int state)
        {
            if (leftDoorState != null)
            {
                leftDoorState(this, new ValueSetEventArgs() { Id = 11, Value = state });
            }
        }

        private void raiseRigthDoorStateChanged(int state)
        {
            if (rigthDoorState != null)
            {
                rigthDoorState(this, new ValueSetEventArgs() { Id = 12, Value = state });
            }
        }

        private void raiseHoodStateChanged(int state)
        {
            if (hoodState != null)
            {
                hoodState(this, new ValueSetEventArgs() { Id = 13, Value = state });
            }
        }

        private void raiseTrunkStateChanged(int state)
        {
            if (trunkState != null)
            {
                trunkState(this, new ValueSetEventArgs() { Id = 14, Value = state });
            }
        }

        private void raiseSuspensionStateChanged(int value)
        {
            if (suspensionStateChanged != null)
            {
                suspensionStateChanged(this, new ValueSetEventArgs() { Id = 4, Value = value });
            }
        }

        private void raiseFanSpeedStateChanged(int value)
        {
            if (fanSpeedChanged != null)
            {
                fanSpeedChanged(this, new ValueSetEventArgs() { Id = 1, Value = value });
            }
        }

        private void raiseSpoilerModeChanged(int value)
        {
            if (spoilerModeChanged != null)
            {
                spoilerModeChanged(this, new ValueSetEventArgs() { Id = 6, Value = value });
            }
        }

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
            switch(buff.SetValueSubCommand.Id)
            {
                case 1:
                    raiseFanSpeedStateChanged(buff.SetValueSubCommand.IValue);
                    break;
                case 4:
                    raiseSuspensionStateChanged(buff.SetValueSubCommand.IValue);
                    break;
                case 6:
                    raiseSpoilerModeChanged(buff.SetValueSubCommand.IValue);
                    break;
            }
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

        private int _batteryVoltage;
        public int batteryVoltage
        {
            get
            {
                return _batteryVoltage;
            }
            set
            {
                _batteryVoltage = value;
                ServerCommandBuff buff = new ServerCommandBuff();
                buff.ValueSettedSubCommand = new ValueSettedSubCommand();
                buff.ValueSettedSubCommand.Id = 9;
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

        private int _batteryCurrent;
        public int batteryCurrent
        {
            get
            {
                return _batteryCurrent;
            }
            set
            {
                _batteryCurrent = value;
                ServerCommandBuff buff = new ServerCommandBuff();
                buff.ValueSettedSubCommand = new ValueSettedSubCommand();
                buff.ValueSettedSubCommand.Id = 10;
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
