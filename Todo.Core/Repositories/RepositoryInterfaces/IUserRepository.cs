using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Common.Dto;
using Todo.Domain.Entities;
using Todo.Domain.Infrastructure;

namespace Todo.Core.Repositories.RepositoryInterfaces
{
    public interface IUserRepository
    {
        DtoUser ValidatePassword(string eMailAddress, string password);
    }
}
