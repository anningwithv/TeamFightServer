using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotonHostRuntimeInterfaces;
using ExitGames.Logging.Log4Net;
using log4net;
using log4net.Config;
using System.IO;
using ExitGames.Logging;

namespace TeamFightServer
{
    public class TeamFightApplication : ApplicationBase
    {
        private static readonly ILogger log = ExitGames.Logging.LogManager.GetCurrentClassLogger();

        private static TeamFightApplication _instance;

        public static TeamFightApplication Instance
        {
            get { return _instance; }
        }

        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new ClientPeer(initRequest.Protocol, initRequest.PhotonPeer);
        }

        protected override void Setup()
        {
            ExitGames.Logging.LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
            GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            GlobalContext.Properties["LogFileName"] = "TD" + this.ApplicationName;
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(this.BinaryPath, "log4net.config")));

            log.Debug("TeamFight server application setup complete.");
        }

        protected override void TearDown()
        {
            log.Debug("TeamFight server application tear down.");
        }
    }
}
