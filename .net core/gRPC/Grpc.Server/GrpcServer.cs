using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace Grpc.Server
{
    public class GrpcServer
    {
        private readonly Grpc.Core.Server serverInstance;

        public GrpcServer(string host, int port, params ServerServiceDefinition[] serverServices)
        {
            serverInstance = new Grpc.Core.Server
            {
                Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
            };
            foreach (var item in serverServices)
            {
                serverInstance.Services.Add(item);
            }
            serverInstance.Start();
        }
    }
}
