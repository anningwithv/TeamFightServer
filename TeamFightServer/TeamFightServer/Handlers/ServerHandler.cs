using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using TeamFightCommon;
using LitJson;
using TeamFightCommon.Model;

namespace TeamFightServer.Handlers
{
    public class ServerHandler : HandlerBase
    {
        //private UserManager manager;

        public ServerHandler()
        {
            //manager = new UserManager();
        }

        public override void OnHandlerMessage(Photon.SocketServer.OperationRequest request, OperationResponse response, ClientPeer peer, SendParameters sendParameters)
        {
            //List<ServerProperty> list = manager.GetServerList();
            List<ServerProperty> list = new List<ServerProperty>();
            list.Add(new ServerProperty { ID = 1, Name = "1区", Count = 100 });
            list.Add(new ServerProperty { ID = 2, Name = "2区", Count = 200 });

            string json = JsonMapper.ToJson(list);
            Dictionary<byte, object> parameters = response.Parameters;
            parameters.Add((byte)ParameterCode.ServerList, json);

            response.OperationCode = request.OperationCode;
            response.ReturnCode = (short)ReturnCode.Success;
        }

        public override OperationCode OpCode
        {
            get { return OperationCode.GetServer; }
        }
    }
}
