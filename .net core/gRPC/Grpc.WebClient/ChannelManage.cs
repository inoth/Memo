using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grpc.WebClient
{
    public class ChannelManage
    {
        //public IEnumerable<ChannelBase> channels { get; set; }

        private Dictionary<string, ChannelBase> channelsDic;
        public ChannelManage(IEnumerable<ChannelBase> channels)
        {
            channelsDic = new Dictionary<string, ChannelBase>();
            foreach (var chan in channels)
            {
                channelsDic.TryAdd(chan.Target, chan);
            } // 初始化远程管道
        }

        public ChannelBase GetChannel(string target)
        {
            if (channelsDic.TryGetValue(target, out ChannelBase chan))
                return chan;
            return null;
        }
    }
}
