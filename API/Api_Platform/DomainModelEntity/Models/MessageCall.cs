using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelEntity.Models
{
	public class MessageCall
	{
		[Key]
		public int Id { get; set; }
		public int userid { get; set; }
		public int otherid { get; set; }
	}
}
