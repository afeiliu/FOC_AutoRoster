using Demo.Core.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services.Customer
{
    public interface IUserService
    {
        IList<User> GetAll(int pageIndex, int pageSize, out int total);
    }
}
