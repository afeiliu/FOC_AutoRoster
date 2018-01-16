using Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.Domain.Customer;

namespace Demo.Services.Customer
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService()
            : this(new DemoEfRepository<User>())
        {
        }

        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public virtual IList<User> GetAll(int pageIndex, int pageSize, out int total)
        {
            var query = _userRepository.Table;

            total = query.Count();

            return query.OrderBy(order => order.EmpNo).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}
