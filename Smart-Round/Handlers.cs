using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace Smart_Round
{
    public class Handlers
    {
        public CoroutineHandle SrCoroutineHandle;


        public void RoundStarted()
        {
            SrCoroutineHandle = Timing.RunCoroutine(SrCoroutine());
        }

        public void RoundEnded(RoundEndedEventArgs e)
        {
            Timing.KillCoroutines(SrCoroutineHandle);
        }

        public IEnumerator<float> SrCoroutine()
        {
            bool OnePlayerLeft = Player.List.Count() <= 1;
            while (Round.IsStarted)
            {
                yield return Timing.WaitForSeconds(0.5f);
                if (OnePlayerLeft)
                {
                    yield return Timing.WaitForSeconds(Plugin.Singleton.Config.SecondsBeforeRestart);
                    if (OnePlayerLeft)
                    {
                        Player.List.First().Broadcast(Plugin.Singleton.Config.BroadcastLastPlayer);
                        yield return Timing.WaitForSeconds(Plugin.Singleton.Config.BroadcastLastPlayer.Duration);
                        Server.Restart();
                    }
                }
            }
        }
    } 
}
