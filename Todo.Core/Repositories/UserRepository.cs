using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Common.Dto;
using Todo.Common.Helpers;
using Todo.Core.Repositories.RepositoryInterfaces;
using Todo.Domain.Entities;

namespace Todo.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public DtoUser ValidatePassword(string eMailAddress, string password)
        {
            var user = Get(u => u.EMailAddress == eMailAddress);

            if (user != null && Hasher.ValidatePassword(password, user.PasswordHash))
            {
                return new DtoUser
                {
                    Id = user.Id,
                    EMailAddress = user.EMailAddress,
                    FullName = user.FullName
                };
            }

            return null;
        }
    }
}
