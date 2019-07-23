using System.Threading.Tasks;
using Grpc.Core;

namespace UserService
{
    public class PersonaService : Persona.PersonaBase
    {
        public override Task<UserInfo> QueryUser(UserInfo request, ServerCallContext context)
        {
            return Task.FromResult(new UserInfo
            {
                Id = 1,
                Name = request.Name,
                Gmail = $"{request.Name}.work@gmail.com"
            });
        }
    }
}