using System.ComponentModel.DataAnnotations;
using Todo.Domain.Infrastructure;

namespace Todo.Domain.Entities
{
    public class User : BaseEntity
    {
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(250)]
        public string EMailAddress { get; set; }

        [StringLength(250)]
        public string PasswordHash { get; set; }
    }
}
