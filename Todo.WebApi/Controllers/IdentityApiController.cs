using System.Web.Http;
using Todo.Common.Dto;
using Todo.Core.Repositories.RepositoryInterfaces;

namespace Todo.WebApi.Controllers
{
    public class IdentityApiController : ApiController
    {
        private IUserRepository _userRepository;

        public IdentityApiController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public DtoUser ValidateLogin(DtoLogin model)
        {
            return _userRepository.ValidatePassword(model.EMailAddress, model.Password);
        }
    }
}
