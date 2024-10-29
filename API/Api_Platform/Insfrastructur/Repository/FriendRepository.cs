using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DomainModelEntity.Models;

namespace Insfrastructur.Repository
{
	public class FriendRepository : RepositoryBase<Friend>, IFriend
	{
		public FriendRepository(AppDbContext appDbContext) : base(appDbContext)
		{

		}
	}
}
