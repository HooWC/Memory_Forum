using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelEntity.Models
{
	public class Message
	{
		[Key]
		public int Id { get; set; }
		public int userid { get; set; }
		public int friendid { get; set; }
		public string? word { get; set; }
		public DateTime date { get; set; }
	}
}
