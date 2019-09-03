using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Message;
using Microsoft.AspNetCore.Mvc;

namespace Grpc.WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController
    {
        private readonly PersonaService.PersonaServiceClient client;
        private readonly SkillService.SkillServiceClient client2;

        private string LocalIP { get; set; }

        public ValuesController(ChannelManage chanManage)
        {
            //this.client = new PersonaService.PersonaServiceClient(chanManage.GetChannel("localhost:50051"));
            this.client = new PersonaService.PersonaServiceClient(chanManage.GetChannel("10.104.10.96:9999"));
            this.client2 = new SkillService.SkillServiceClient(chanManage.GetChannel("10.104.10.96:9999"));

            LocalIP = NetworkInterface.GetAllNetworkInterfaces()
                 .Select(p => p.GetIPProperties())
                 .SelectMany(p => p.UnicastAddresses)
                 .Where(p => p.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(p.Address))
                 .FirstOrDefault()?.Address.ToString();

        }

        [HttpGet("/ip")]
        public ActionResult<string> GetIp()
        {
            return this.LocalIP;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<SkillInfo>> Get()
        {
            return await client2.QueryAsync(new SkillInfo());
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> Get(string id)
        {
            return await client.QueryAsync(new UserInfo { Name = id });
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
