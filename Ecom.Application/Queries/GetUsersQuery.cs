using Ecom.Core.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Application.Queries
{
    public class GetUsersQuery: IRequest<List<AppUser>>
    {

    }
}
