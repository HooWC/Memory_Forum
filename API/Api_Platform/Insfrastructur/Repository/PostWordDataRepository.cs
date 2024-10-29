using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DomainModelEntity.Models;

namespace Insfrastructur.Repository
{
	internal class PostWordDataRepository : RepositoryBase<PostWordData>, IPostWordData
	{
		public PostWordDataRepository(AppDbContext appDbContext) : base(appDbContext)
		{

		}
	}
}
