using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using UserService;

namespace RPCClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:50051");

            var client = GrpcClient.Create<Persona.PersonaClient>(http);
            var r = await client.QueryUserAsync(new UserInfo
            {
                Name = "inoth"
            });
            System.Console.WriteLine($"name is {r.Name}");
            System.Console.WriteLine($"gmail is {r.Gmail}");

            // 不推荐如此
            var client2 = GrpcClient.Create<Greeter.GreeterClient>(http);
            var r2 = await client2.SayHelloAsync(new HelloRequest
            {
                Name = "kayano"
            });
            System.Console.WriteLine($"message is {r2.Message}");
        }
    }
}
