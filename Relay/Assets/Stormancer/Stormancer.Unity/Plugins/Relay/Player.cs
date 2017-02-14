using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stormancer.Plugins.Relay
{
    public class Player
    {
        public byte[] UserData { get; set; }
        public long ConnectionId { get; set; }
    }
}
