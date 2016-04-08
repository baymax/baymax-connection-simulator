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
using Google.Protobuf.WellKnownTypes;

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

        /*
        private void raiseLeftDoorStateChanged(uint state)
        {
            if (leftDoorState != null)
            {
                leftDoorState(this, new ValueSetEventArgs() { Id = 11, Value = state });
            }
        }

        private void raiseRigthDoorStateChanged(uint state)
        {
            if (rigthDoorState != null)
            {
                rigthDoorState(this, new ValueSetEventArgs() { Id = 12, Value = state });
            }
        }

        private void raiseHoodStateChanged(uint state)
        {
            if (hoodState != null)
            {
                hoodState(this, new ValueSetEventArgs() { Id = 13, Value = state });
            }
        }

        private void raiseTrunkStateChanged(uint state)
        {
            if (trunkState != null)
            {
                trunkState(this, new ValueSetEventArgs() { Id = 14, Value = state });
            }
        }*/

        private ulong getDateInSeconds()
        {
            DateTime dt = DateTime.Now;
            DateTime dtStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long ticks = dt.Ticks - dtStart.Ticks;
            return (ulong)ticks / TimeSpan.TicksPerSecond;
        }

        private void raiseSuspensionStateChanged(uint value)
        {
            if (suspensionStateChanged != null)
            {
                suspensionStateChanged(this, new ValueSetEventArgs() { Id = 4, Value = value });
            }
        }

        private void raiseFanSpeedStateChanged(uint value)
        {
            if (fanSpeedChanged != null)
            {
                fanSpeedChanged(this, new ValueSetEventArgs() { Id = 1, Value = value });
            }
        }

        private void raiseSpoilerModeChanged(uint value)
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
                    raiseFanSpeedStateChanged(buff.SetValueSubCommand.OtherValue);
                    break;
                case 4:
                    raiseSuspensionStateChanged(buff.SetValueSubCommand.OtherValue);
                    break;
                case 6:
                    raiseSpoilerModeChanged(buff.SetValueSubCommand.OtherValue);
                    break;
            }
        }

        private void WebSocket_Closed(object sender, EventArgs e)
        {

        }

        private void WebSocket_Opened(object sender, EventArgs e)
        {

        }
        uint _fanSpeed;
        public uint fanSpeed {
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
                buff.ValueSettedSubCommand.OtherValue = value;
                buff.ValueSettedSubCommand.DateSeconds = getDateInSeconds();
                byte[] data;
                using (var ms = new MemoryStream())
                {
                    buff.WriteTo(ms);
                    data = ms.ToArray();
                }
                webSocket.Send(data, offset: 0, length: data.Length);
            }
        }

        uint _suspensionMode;
        public uint suspensionMode {
            get
            {
                return _suspensionMode;
            }
            set
            {
                _suspensionMode = value;
                ServerCommandBuff buff = new ServerCommandBuff();
                buff.ValueSettedSubCommand = new ValueSettedSubCommand();
                buff.ValueSettedSubCommand.Id = 4;
                buff.ValueSettedSubCommand.OtherValue = value;
                buff.ValueSettedSubCommand.DateSeconds = getDateInSeconds();
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

        uint _spoilerMode;
        public uint spoilerMode {
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
                buff.ValueSettedSubCommand.OtherValue = value;
                buff.ValueSettedSubCommand.DateSeconds = getDateInSeconds();
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

        private uint _batteryVoltage;
        public uint batteryVoltage
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
                buff.ValueSettedSubCommand.VoltageValue = value;
                buff.ValueSettedSubCommand.DateSeconds = getDateInSeconds();
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

        private uint _batteryCurrent;
        public uint batteryCurrent
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
                buff.ValueSettedSubCommand.CurrentValue = value;
                buff.ValueSettedSubCommand.DateSeconds = getDateInSeconds();
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
