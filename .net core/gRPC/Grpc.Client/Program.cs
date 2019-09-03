using Grpc.Core;
using Grpc.Message;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace Grpc.Client
{
    class Program
    {
        //static async Task Main(string[] args)
        static void Main(string[] args)
        {
            //Channel channel = new Channel("localhost:50051", ChannelCredentials.Insecure);

            //var user = new UserInfo { Name = "inoth" };

            //var c1 = new PersonaService.PersonaServiceClient(channel);
            //var r = await c1.SayHiAsync(user);
            //Console.WriteLine(r.Msg);

            //var r2 = await c1.QueryAsync(user);
            //Console.WriteLine(JsonConvert.SerializeObject(r2));

            //var r3 = await c1.QueryListAsync(user);
            //Console.WriteLine(JsonConvert.SerializeObject(r3));

            //await channel.ShutdownAsync();
            var ip = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                 .Select(p => p.GetIPProperties())
                 .SelectMany(p => p.UnicastAddresses)
                 .Where(p => p.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !System.Net.IPAddress.IsLoopback(p.Address))
                 ;
            //.FirstOrDefault()?.Address.ToString();
            foreach (var item in ip)
            {
                Console.WriteLine(item?.Address.ToString());
            }

            Console.ReadKey();
        }
    }
}
