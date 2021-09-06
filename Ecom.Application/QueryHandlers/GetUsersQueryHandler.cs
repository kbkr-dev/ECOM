using Ecom.Application.Queries;
using Ecom.Core.Domain.Users;
using Ecom.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecom.Application.QueryHandlers
{
    public class GetUsersQueryHandler: IRequestHandler<GetUsersQuery, List<AppUser>>
    {
        private readonly IGenericRepository<AppUser> _userRepository;

        public GetUsersQueryHandler(IGenericRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<AppUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.GetAll().ToList());
        }
    }
}
