using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DomainModelEntity.Models;

namespace Insfrastructur.Repository
{
	internal class PostWordDataCommentRepository : RepositoryBase<PostWordDataComment>, IPostWordDataComment
	{
		public PostWordDataCommentRepository(AppDbContext appDbContext) : base(appDbContext)
		{

		}
	}
}
