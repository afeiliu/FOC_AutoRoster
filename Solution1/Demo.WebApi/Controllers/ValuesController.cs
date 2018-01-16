using Demo.Core.Domain.Customer;
using Demo.Services.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace Demo.WebApi.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private readonly IUserService _userService;
        public ValuesController()
            : this(new UserService())
        {
        }

        public ValuesController(IUserService userService)
        {
            this._userService = userService;
        }

        public IHttpActionResult Get()
        {
            int total;
            List<User> entities = _userService.GetAll(1, 10, out total).ToList();

            return Ok(new
            {
                total = total,
                data = entities
            });
        }
    }
}