using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API;
using Exiled.API.Features;
using PlayerEv = Exiled.Events.Handlers.Player;
using ServerEv = Exiled.Events.Handlers.Server;


namespace Smart_Round
{
    public class Plugin : Plugin<Config>
    {
        public Handlers Handlers { get; private set; }
        public static Plugin Singleton { get; private set; }

        public override string Author { get; } = "MaxPlay066";
        public override string Name { get; } = "SmartRound";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(4, 2, 2);
        public override string Prefix { get; } = "SR";

        public override void OnEnabled()
        {
            Handlers = new Handlers();
            Singleton = this;
            ServerEv.RoundStarted += Handlers.RoundStarted;
            ServerEv.RoundEnded += Handlers.RoundEnded;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEv.RoundStarted -= Handlers.RoundStarted;
            ServerEv.RoundEnded -= Handlers.RoundEnded;
            Handlers = null;
            base.OnDisabled();
        }
    }
}