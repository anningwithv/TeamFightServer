using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotonHostRuntimeInterfaces;
using ExitGames.Logging;
using TeamFightServer.Handlers;

namespace TeamFightServer
{
    public class ClientPeer : PeerBase
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

            HandlerBase handler;
            TeamFightApplication.Instance.m_handlers.TryGetValue(operationRequest.OperationCode, out handler);
            OperationResponse response = new OperationResponse();
            response.OperationCode = operationRequest.OperationCode;
            response.Parameters = new Dictionary<byte, object>();
            if (handler != null)
            {
                handler.OnHandlerMessage(operationRequest, response, this, sendParameters);
                SendOperationResponse(response, sendParameters);
            }
            else
            {
                log.Debug("Can't find handler from operation code : " + operationRequest.OperationCode);
            }
        }
    }
}
