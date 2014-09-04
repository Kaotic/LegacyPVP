using LegacyPVP.RtmpsLogic;
using RiotRtmpDto.Platform.Clientfacade.Domain;
using RiotRtmpDto.Platform.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LegacyPVP.Logic.RtmpsLogic
{
    public class HeartBeat
    {
        private static Timer HeartbeatTimer;
        internal static int HeartbeatCount;

        /// <summary>
        /// Packet recieved when initially logged on. Cached so the packet doesn't
        /// need to requested multiple times, causing slowdowns
        /// </summary>
        internal static LoginDataPacket LoginPacket;

        internal static Session PlayerSession;

        internal static bool IsLoggedIn = false;

        public static void StartTimer()
        {
            HeartbeatTimer = new System.Timers.Timer();
            HeartbeatTimer.Elapsed += new ElapsedEventHandler(DoHeartbeat);
            HeartbeatTimer.Interval = 120000; // in milliseconds
            HeartbeatTimer.Start();
            //As soon as we login, we want to do a heartbeat right away
            DoHeartbeat();
        }
        public static void StopTimer()
        {
            HeartbeatTimer = new System.Timers.Timer();
            HeartbeatTimer.Elapsed -= new ElapsedEventHandler(DoHeartbeat);
            HeartbeatTimer.Stop();
        }
        internal static void DoHeartbeat(object sender, ElapsedEventArgs e)
        {
            if (IsLoggedIn)
            {
                DoHeartbeat();
            }
        }
        private async static void DoHeartbeat()
        {
            string result = await RiotCalls.PerformLCDSHeartBeat(Convert.ToInt32(LoginPacket.AllSummonerData.Summoner.AcctId), PlayerSession.Token, HeartbeatCount,
                            DateTime.Now.ToString("ddd MMM d yyyy HH:mm:ss 'GMT-0700'"));

            HeartbeatCount++;
        }
    }
}
