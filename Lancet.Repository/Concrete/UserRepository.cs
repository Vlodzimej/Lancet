using Lancet.Models.Domain.Model;
using Lancet.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LancetContext _LancetContext) : base(_LancetContext)
        { }
    }
}
