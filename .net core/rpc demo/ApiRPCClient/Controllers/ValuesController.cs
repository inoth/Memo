using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using UserService;

namespace ApiRPCClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private HttpClient _http;
        public ValuesController(IHttpClientFactory http)
        {
            // http.BaseAddress = new Uri("http://localhost:50010");
            this._http = http.CreateClient();
            this._http.BaseAddress = new Uri("http://localhost:50010");
            // this._http.DefaultRequestVersion = new Version(2, 0);
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<UserInfo>> Get()
        {
            var client = GrpcClient.Create<Persona.PersonaClient>(this._http);
            var client2 = GrpcClient.Create<Greeter.GreeterClient>(this._http);
            var r = await client2.SayHelloAsync(new HelloRequest { Name = "inoth" });
            System.Console.WriteLine(r.Message);
            return await client.QueryUserAsync(new UserInfo { Name = "inoth" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UserInfo> Get(int id)
        {
            return new UserInfo
            {
                Id = 1,
                Name = "inoth",
                Gmail = "inoth.work@gmail.com"
            };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
