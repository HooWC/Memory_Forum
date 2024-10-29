using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DomainModelEntity.Models;

namespace Insfrastructur.Repository
{
	public class PostWordRepository : RepositoryBase<PostWord>, IPostWord
	{
		public PostWordRepository(AppDbContext appDbContext) : base(appDbContext)
		{

		}
	}
}
