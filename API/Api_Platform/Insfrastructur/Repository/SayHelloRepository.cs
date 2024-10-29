using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DomainModelEntity.Models;

namespace Insfrastructur.Repository
{
	public class SayHelloRepository : RepositoryBase<SayHello>, ISayHello
	{
		public SayHelloRepository(AppDbContext appDbContext) : base(appDbContext)
		{

		}
	}
}
