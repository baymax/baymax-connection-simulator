﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baymax_connection_simulator
{
    class ValueSetEventArgs : EventArgs
    {
        public int Id { get; set; }
        public uint Value { get; set; }
    }
}
