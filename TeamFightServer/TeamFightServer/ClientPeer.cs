using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotonHostRuntimeInterfaces;
using ExitGames.Logging;

namespace TeamFightServer
{
    class ClientPeer : PeerBase
    {
        private static readonly ILogger log = ExitGames.Logging.LogManager.GetCurrentClassLogger();

        public ClientPeer(IRpcProtocol protocol, IPhotonPeer peer)
            : base(protocol, peer)
        {
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            log.Debug("A client is disconnect.");
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            log.Debug("Server get client operation request.");
        }
    }
}
