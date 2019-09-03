using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Message;

namespace Grpc.Server
{
    public class SkillServer : SkillService.SkillServiceBase
    {
        public override Task<SkillInfo> Query(SkillInfo request, ServerCallContext context)
        {
            return Task.FromResult(new SkillInfo
            {
                Id = 1,
                Owner = 1,
                SkName = "UBW",
                SkDesc = "XXXXXXXXXXXXXXXXXXXXX"
            });
        }
    }
}
