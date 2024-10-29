using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform_DomainModelEntity.Models
{
	public class SayHello
	{
		public int Id { get; set; }
		public int userId { get; set; }
		public int otherUserId { get; set; }
		public DateTime date { get; set; }
	}
}
