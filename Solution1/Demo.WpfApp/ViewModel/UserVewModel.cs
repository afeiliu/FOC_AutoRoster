using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WpfApp.ViewModel
{
    public class UserVewModel
    {
        public int Id { get; set; }

        public string EmpNo { get; set; }

        public string Name { get; set; }

        public string Education { get; set; }

        public string School { get; set; }

        public string Job { get; set; }

        public string JobAddress { get; set; }

        public string JobName { get; set; }
    }

    public class BaseViewModel
    {
        public BaseViewModel()
        {
            data = new List<UserVewModel>();
        }

        public int total { get; set; }

        public List<UserVewModel> data { get; set; }
    }
}
