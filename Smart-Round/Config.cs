using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using System.ComponentModel;
using Exiled.API.Features;

namespace Smart_Round
{
    public class Config : IConfig
    {
        [Description("Is this plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("How much seconds needs to pass before restarting?")]
        public int SecondsBeforeRestart { get; set; } = 15;

        [Description("Write here the duration of the broadcast, and his content to the last player")]
        public Exiled.API.Features.Broadcast BroadcastLastPlayer { get; set; } = new Exiled.API.Features.Broadcast("<color=red>As you are the last person in this round, the round will be restarted</color>", 10);


    }
}
