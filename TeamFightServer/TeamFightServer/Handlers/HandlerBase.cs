using ExitGames.Logging;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamFightCommon;

namespace TeamFightServer.Handlers
{
    public abstract class HandlerBase
    {
        private static readonly ILogger log = ExitGames.Logging.LogManager.GetCurrentClassLogger();

        public HandlerBase()
        {
            TeamFightApplication.Instance.m_handlers.Add((byte)OpCode, this);
            log.Debug("Hanlder:" + this.GetType().Name + "  is register.");
        }

        public abstract void OnHandlerMessage(OperationRequest request, OperationResponse response, ClientPeer peer, SendParameters sendParameters);
        public abstract OperationCode OpCode { get; }
    }
}
