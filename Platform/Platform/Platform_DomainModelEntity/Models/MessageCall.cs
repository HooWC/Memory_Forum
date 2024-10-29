using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform_DomainModelEntity.Models
{
	public class MessageCall
	{
		public int Id { get; set; }
		public int userid { get; set; }
		public int otherid { get; set; }
	}
}
