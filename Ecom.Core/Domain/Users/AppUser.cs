using Ecom.BuildingBlocks.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Domain.Users
{
    public class AppUser: EntityBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
