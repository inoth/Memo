using Grpc.Core;
using Grpc.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.Server
{
    public class PersonaServer : PersonaService.PersonaServiceBase
    {
        public override Task<UserInfo> Query(UserInfo request, ServerCallContext context)
        {
            return Task.FromResult(new UserInfo
            {
                Id = 1,
                Name = request.Name,
                Gmail = $"{request.Name}.work@gmail.com"
            });
        }
        public override Task<UserList> QueryList(UserInfo request, ServerCallContext context)
        {
            var list = new UserList();
            list.Item.Add(new UserInfo
            {
                Id = 1,
                Name = request.Name,
                Gmail = $"{request.Name}.work@gmail.com"
            });
            return Task.FromResult(list);
        }
        public override Task<UserMsg> SayHi(UserInfo request, ServerCallContext context)
        {
            return Task.FromResult(new UserMsg { Msg = $"hi {request.Name}" });
        }
    }
}
